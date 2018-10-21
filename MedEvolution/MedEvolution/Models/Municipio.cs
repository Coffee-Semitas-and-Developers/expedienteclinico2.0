using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Municipio")]
    public class Municipio
    {
        public Municipio()
        {
        }

        [Key]
        [Description("Código Municipio:")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoMunicipio { get; set; }

        [Required]
        [Description("Nombre Municipio:")]
        [StringLength(30)]
        public string NombreMun { get; set; }
        
        public Departamento Departamento { get; set; }

    
    }
}