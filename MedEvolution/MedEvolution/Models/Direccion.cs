﻿using System;
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
        [Description("Colonia:")]
        public string Colonia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        [Description("Pasaje o calle:")]
        public string Pasaje_calle { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        [Description("Casa:")]
        public string Casa { get; set; }

        [Required]
        [StringLength(50)]
        [Description("Detalle:")]
        public string Detalle { get; set; }

        public Municipio Municipio { get; set; }

    }
}