using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("OrdenExamen")]
    public class OrdenExamen
    {
        [Key]
        public int IdOrden { get; set; }

        [Required]
        public bool Urgencia { get; set; }

        public byte Resultado { get; set; }

        public DateTime FechaResultado { get; set; }

        public virtual Consulta Consulta { get; set; }

        public virtual List<Examen> Examen { get; set; }
    }
}