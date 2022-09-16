namespace ApiAlbumes.Entidades
{
    public class Cancion
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Compositor { get; set; }

        public string Duracion { get; set; }

        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
