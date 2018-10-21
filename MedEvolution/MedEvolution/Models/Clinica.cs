using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Clinica")]
    public class Clinica
    {
        public Clinica()
        {
            FechaApertura = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Identificador clínica:")]
        public int IdClinica { get; set; }

        [Required]
        [StringLength(30)]
        [Description("Nombre de la clínica:")]
        public string NombreClinica { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("####-####")]
        [Description("Teléfono:")]
        public string Telefono { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [ScaffoldColumn(false)]
        public DateTime FechaApertura { get; set; }

        public Direccion Direccion { get; set; }
        
        public Empleado Director { get; set; }

        public List<Empleado> Empleados { get; set; }

    }
}