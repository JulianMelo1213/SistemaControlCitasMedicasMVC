using System.ComponentModel.DataAnnotations;

namespace SistemaControlCitasMedicasMVC.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La especialidad no puede exceder 100 caracteres.")]
        public string Especialidad { get; set; }
    }
}
