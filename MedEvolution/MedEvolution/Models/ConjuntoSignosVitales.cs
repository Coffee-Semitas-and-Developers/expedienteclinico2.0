
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MedEvolution.Models
{
    [Table("ConjuntoSignosVitales")]
    public class ConjuntoSignosVitales
    {
        public ConjuntoSignosVitales()
        {
            Consultas = new HashSet<Consulta>();
        }

        [Key]
        public int IdSignos { get; set; }

        [Required]
        public decimal PresionArterial { get; set; }

        [Required]
        public decimal Teperatura { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public decimal PulsoCardiaco { get; set; }

        [Required]
        public decimal Estatura { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
    

