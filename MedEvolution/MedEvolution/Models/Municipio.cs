﻿using System;
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
        [DisplayName("Código Municipio:")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoMunicipio { get; set; }

        [Required]
        [DisplayName("Nombre Municipio:")]
        [StringLength(30)]
        public string NombreMun { get; set; }

        [DisplayName("Departamento:")]
        public int codigoDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }

    
    }
}