using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Clinica")]
    public class Clinica
    {
        Clinica()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClinica { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreClinica { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("####-####")]
        public string Telefono { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MMM/yyyy")]
        public DateTime FechaApertura { get; set; }

        public virtual Direccion Direccion { get; set; }
        
        //public virtual Empleado Director { get; set; }

    }
}