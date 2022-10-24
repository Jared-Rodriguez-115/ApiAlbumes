using ApiAlbumes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApiAlbumes.Services;
using ApiAlbumes.Filtros;


namespace ApiAlbumes.Controllers
{
    [ApiController]
    [Route("albumes")]
    public class AlbumesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<AlbumesController> logger;
        
        public AlbumesController(ApplicationDbContext dbContext, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton, ILogger<AlbumesController> logger)
        {
            this.dbContext = dbContext;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
        }

        [HttpGet] // /albumes
        [HttpGet("listado")] //albumes/listado
        [HttpGet("/listado")] // /listado
    
        public async Task<ActionResult<List<Album>>> Get()
        {
            logger.LogInformation("Se obtiene el listado de albumes");
            logger.LogWarning("Mensaje de prueba Warning");
            service.EjecutarJob();
            return await dbContext.Albumes.Include(x => x.Canciones).ToListAsync();
        }

        [HttpGet("primero")] //albumes/primero

        public async Task<ActionResult<Album>> PrimerAlbum([FromHeader] int valor, [FromQuery] string album, [FromQuery] int albumId)
        {
            return await dbContext.Albumes.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}/{param=Pet Sounds}")] //albumes/(id)

        public async Task<ActionResult<Album>> Get(int id, string param)
        {
           var album = await dbContext.Albumes.FirstOrDefaultAsync(x => x.Id == id);

            if(album == null)
            {
                return NotFound();
            }

            return album;
        }

        [HttpGet("{nombre}")] //albumes/(nombre)

        public async Task<ActionResult<Album>> Get([FromRoute]string nombre)
        {
            var album = await dbContext.Albumes.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Album album)
        {

            var existeAlbumMismoNombre = await dbContext.Albumes.AnyAsync(x => x.Nombre == album.Nombre);

            if (existeAlbumMismoNombre)
            {
                return BadRequest("Ya existe un album con el mismo nombre");
            }

            dbContext.Add(album);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Album album, int id)
        {
            if(album.Id != id)
            {
                return BadRequest("El id del album no coincide con el establecido en la url.");
            }

            dbContext.Update(album);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Albumes.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Album()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
