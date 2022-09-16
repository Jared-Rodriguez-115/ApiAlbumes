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

        [HttpGet]
        public async Task<ActionResult<List<Album>>> Get()
        {
            return await dbContext.Albumes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Album album)
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

    }
}
