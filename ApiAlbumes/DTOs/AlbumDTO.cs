using System.ComponentModel.DataAnnotations;
using ApiAlbumes.Validaciones;

namespace ApiAlbumes.DTOs
{
    public class AlbumDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
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
    }
}
