using ApiAlbumes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAlbumes.Controllers
{
    [ApiController]
    [Route("albumes")]
    public class AlbumesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AlbumesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet] // /albumes
        [HttpGet("listado")] //albumes/listado
        [HttpGet("/listado")] // /listado
    
        public async Task<ActionResult<List<Album>>> Get()
        {
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
