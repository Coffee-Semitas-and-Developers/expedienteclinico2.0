using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

    namespace MedEvolution.Models
    {
        [Table("Receta")]
        public partial class Receta
        {
            [Key]
            public int IdReceta { get; set; }

            [Required]
            [StringLength(254)]
            public string Instrucciones { get; set; }

            public virtual Consulta Consulta { get; set; }

            public virtual Medicamento Medicamento { get; set; }
        }
    }
    
