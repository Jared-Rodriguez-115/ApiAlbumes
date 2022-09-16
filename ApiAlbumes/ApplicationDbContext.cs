using ApiAlbumes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiAlbumes
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Album> Albumes { get; set; }

        public DbSet<Cancion> Canciones { get; set; }
    }
}
