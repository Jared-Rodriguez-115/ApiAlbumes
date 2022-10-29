//using Microsoft.AspNetCore.Components.Forms;

namespace ApiAlbumes.Middlewares
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseHttpMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ResponseHttpMiddleware>();
        }
    }
    public class ResponseHttpMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<ResponseHttpMiddleware> logger;

        public ResponseHttpMiddleware(RequestDelegate siguiente, 
            ILogger<ResponseHttpMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

        //Requerimos del metodo InvokeAsync para hacer uso de la clase Middleware
        //Debe retornanos un Task.
        public async Task InvokeAsync(HttpContext context)
        {
            using (var ms = new MemoryStream())
            {
                //Asignamos el body del response a una variable y se le da el valor de memorystream
                var bodyOriginal = context.Response.Body;
                context.Response.Body = ms;

                //Permite continuar la linea
                await siguiente(context);

                //Guardamos la respuesta en un string
                ms.Seek(0, SeekOrigin.Begin);
                string response = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);

                //Leemos el string y lo colocamos como estaba
                await ms.CopyToAsync(bodyOriginal);
                context.Response.Body = bodyOriginal;

                logger.LogInformation(response);
            }
        }
    }
}
