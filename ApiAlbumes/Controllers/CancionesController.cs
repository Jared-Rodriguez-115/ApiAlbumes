using ApiAlbumes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAlbumes.Controllers
{

    [ApiController]
    [Route("api/canciones")]
    public class CancionesController: ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public CancionesController (ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Cancion>>> GetAll()
        {
            return await dbContext.Canciones.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Cancion>> GetById(int id)
        {
            return await dbContext.Canciones.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(Cancion cancion)
        {
            var existeAlbum = await dbContext.Albumes.AnyAsync(x => x.Id == cancion.AlbumId);

            if (!existeAlbum)
            {
                return BadRequest($"No existe el album con el id: {cancion.AlbumId}");
            }

            dbContext.Add(cancion);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
