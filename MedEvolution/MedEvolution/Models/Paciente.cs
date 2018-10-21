using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Paciente")]
    public partial class Paciente
    {
        Paciente()
        {
            FechaCreacion = DateTime.Now;
        }

        [Key]
        public int IdPaciente { get; set; }        

        [Required]
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaDeBaja { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Persona Persona { get; set; }

    }
}