using System.ComponentModel.DataAnnotations;

namespace proTaxi.Api.Models.Usuario
{
    public abstract record BaseUserDto
    {
        [Required]
        [StringLength(50)]
        public required string Documento { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public required string Apellido { get; set; }
    }
}
