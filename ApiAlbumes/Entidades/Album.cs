using System.ComponentModel.DataAnnotations;

namespace ApiAlbumes.Entidades
{
    public class Album
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength:10, ErrorMessage = "El campo {0} solo puede tener 10 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} solo puede tener 10 caracteres")]
        public string Artista { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [Range(1950, 2022, ErrorMessage = "El campo Año no se encuentra dentro del rango")]
        public int Año { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido obligatoriamente")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} solo puede tener 5 caracteres")]
        public string Duracion { get; set; }

        public List<Cancion> Canciones { get; set; }

    }
}
