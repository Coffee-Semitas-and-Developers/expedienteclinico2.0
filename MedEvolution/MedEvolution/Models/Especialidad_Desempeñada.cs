using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("EspecialidadDesempeniada")]
    public class Especialidad_Desempeniada
    {
        Especialidad_Desempeniada()
        {
            //Medicos = new HashSet<Medico>();
        }

        [Key]
        public int CodigoEspecialidad { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreEspecialidad { get; set; }

        //public virtual ICollection<Medico> Medicos { get; set; }
    }
}