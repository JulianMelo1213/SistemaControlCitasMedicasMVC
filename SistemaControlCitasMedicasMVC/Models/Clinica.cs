using System.ComponentModel.DataAnnotations;

namespace SistemaControlCitasMedicasMVC.Models
{
    public class Clinica
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la clínica es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres.")]
        public string Direccion { get; set; }
    }
}
