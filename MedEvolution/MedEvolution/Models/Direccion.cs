using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }



        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        [DisplayName("Colonia:")]
        public string Colonia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        [DisplayName("Pasaje o calle:")]
        public string Pasaje_calle { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        [DisplayName("Casa:")]
        public string Casa { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Detalle:")]
        public string Detalle { get; set; }

        [DisplayName("Departamento:")]
        public int codigoDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }

        [DisplayName("Municipio:")]
        public int codigoMunicipio { get; set; }
        public virtual Municipio Municipio { get; set; }

    }
}