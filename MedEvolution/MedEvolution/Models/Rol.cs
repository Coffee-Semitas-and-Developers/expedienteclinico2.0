using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Rol")]
    public class Rol
    {
        /*Aun falta analisis aqui y mejor organizacion*/

        Rol()
        {
            //Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int CodigoRol { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreRol { get; set; }

        public virtual Privilegio Privilegio { get; set; }

        public virtual Menu Menu { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}