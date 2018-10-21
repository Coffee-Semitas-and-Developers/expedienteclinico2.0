using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        public Departamento()
        {
            //Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Description ("Código Departamento:")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoDepartamento { get; set; }

        [Required]
        [Description("Nombre del Departamento:")]
        [StringLength(30)]
        public string NombreDep { get; set; }

        public ICollection<Municipio> Municipios { get; set; }
    }
}