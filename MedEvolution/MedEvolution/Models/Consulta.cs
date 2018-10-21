using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Consulta")]
    public class Consulta
    {
        Consulta()
        {
            Recetas = new HashSet<Receta>();
            OrdenesExamen = new HashSet<OrdenExamen>();
        }

        [Key]
        public int IdConsulta { get; set; }

        [Required]
        [StringLength(254)]
        public string Sintomatología { get; set; }

        [Required]
        [StringLength(254)]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(254)]
        public string Tratamiento { get; set; }

        [Required]
        public DateTime HoraConsulta { get; set; }

        [Required]
        [StringLength(254)]
        public string ProcedimientoEnfermera { get; set; }

        public virtual ICollection<Receta> Recetas  { get; set; }

        public virtual ICollection<OrdenExamen> OrdenesExamen { get; set; }

        public virtual Cita Cita { get; set; }

        public virtual ConjuntoSignosVitales Signos { get; set; }
    }
}