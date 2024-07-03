using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaControlCitasMedicasMVC.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Required(ErrorMessage = "El ID del médico es obligatorio.")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "El ID de la clínica es obligatorio.")]
        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }
    }
}
