using ApiAlbumes.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlbumes.Controllers
{
    [ApiController]
    [Route("albumes")]
    public class AlbumesController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Album>> Get()
        {
            return new List<Album>()
            {
                new Album() {Id=1, Nombre="Pet Sounds", Artista="The Beach Boys", Año=1966, Duracion="35:57 minutos"},
                new Album() {Id=2, Nombre="Revolver", Artista="The Beatles", Año=1966, Duracion="35:01 minutos"}
            };
        }
    }
}
