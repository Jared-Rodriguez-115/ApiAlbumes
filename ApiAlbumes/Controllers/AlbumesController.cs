using ApiAlbumes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApiAlbumes.DTOs;
using ApiAlbumes.Filtros;
using AutoMapper;


namespace ApiAlbumes.Controllers
{
    [ApiController]
    [Route("albumes")]
    public class AlbumesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        
        public AlbumesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }



        [HttpGet] // /albumes
        public async Task<ActionResult<List<GetAlbumDTO>>> Get()
        {
            var albumes = await dbContext.Albumes.ToListAsync();
            return mapper.Map<List<GetAlbumDTO>>(albumes);
        }

        [HttpGet("{id:int}")] //albumes/(id)

        public async Task<ActionResult<GetAlbumDTO>> Get(int id)
        {
           var album = await dbContext.Albumes.FirstOrDefaultAsync(albumBD => albumBD.Id == id);

            if(album == null)
            {
                return NotFound();
            }

            return mapper.Map<GetAlbumDTO>(album);
        }

        [HttpGet("{nombre}")] //albumes/(nombre)

        public async Task<ActionResult<List<GetAlbumDTO>>> Get([FromRoute]string nombre)
        {
            var albumes = await dbContext.Albumes.Where(albumBD => albumBD.Nombre.Contains(nombre)).ToListAsync();

            return mapper.Map <List<GetAlbumDTO>>(albumes);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlbumDTO albumDto)
        {

            var existeAlbumMismoNombre = await dbContext.Albumes.AnyAsync(x => x.Nombre == albumDto.Nombre);

            if (existeAlbumMismoNombre)
            {
                return BadRequest($"Ya existe un album con el nombre {albumDto.Nombre}");
            }

            var album = mapper.Map<Album>(albumDto);

            dbContext.Add(album);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Album album, int id)
        {
            var exist = await dbContext.Albumes.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

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
                return NotFound("El recursos no fue encontrado");
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
