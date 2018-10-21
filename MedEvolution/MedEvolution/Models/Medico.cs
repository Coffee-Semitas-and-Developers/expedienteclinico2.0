using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Medico")]
    public partial class Medico
    {
        public Medico()
        {
            //Citas = new HashSet<Cita>();
        }

        [Key]
        public int Jvpm { get; set; }

        //public virtual ICollection<Cita> Citas { get; set; }
       
        public virtual Empleado Empleado { get; set; }

        public virtual Especialidad_Desempeniada Especialidad_Desempeniada { get; set; }

        public virtual Horario_De_Atencion Horarios_De_Atencion { get; set; }
    }
}