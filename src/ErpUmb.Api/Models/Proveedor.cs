using System.ComponentModel.DataAnnotations;

namespace ErpUmb.Api.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El NIT es obligatorio")]
        [StringLength(20)]
        public string Nit { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Razón Social es obligatoria")]
        [StringLength(150)]
        public string RazonSocial { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}