using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedEvolution.Models
{
    [Table("Direccion")]
    public class Direccion
    {
        public Direccion()
        {
            //Personas = new HashSet<Persona>();
            //Clinicas = new HashSet<Clinica>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Colonia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Pasaje_calle { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string casa { get; set; }

        [Required]
        [StringLength(50)]
        public string Detalle { get; set; }

        public virtual Municipio Municipio { get; set; }

        //public virtual ICollection<Clinica> Clinicas { get; set; }

        //public virtual ICollection<Persona> Personas { get; set; }
    }
}