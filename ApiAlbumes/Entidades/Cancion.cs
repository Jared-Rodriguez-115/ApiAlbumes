using System.ComponentModel.DataAnnotations;

namespace ApiAlbumes.Entidades
{
    public class Cancion
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} solo puede tener 10 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} solo puede tener 10 caracteres")]
        public string Compositor { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} solo puede tener 5 caracteres")]
        public string Duracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
