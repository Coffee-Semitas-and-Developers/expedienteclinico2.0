using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Empleado")]
    public partial class Empleado
    {
        public Empleado()
        {
            //FechaContratacion = DateTime.Today;
            //Medicos = new HashSet<Medico>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmpleado { get; set; }

        [Required]
        [StringLength(30)]
        public string Cargo { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="dd/MMM/yyyy")]
        public DateTime FechaContratacion { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MMM/yyyy")]
        public DateTime? FechaDespido { get; set; }

        public double Salario { get; set; }

        [Required]
        public decimal HorasLaborales { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Clinica Clinica { get; set; }

        public virtual Estado Estado { get; set; }

        //public virtual ICollection<Medico> Medicos { get; set; }
    }
}