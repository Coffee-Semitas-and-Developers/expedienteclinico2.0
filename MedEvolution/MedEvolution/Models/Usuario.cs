using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        /*Aun falta analisis aqui y mejor organizacion*/

        Usuario()
        {
        }

        [Key]
        [EmailAddress]
        public string CorreoElectronicoLaboral { get; set; }

        [Required]
        [StringLength(16)]
        [Description("Contraseña")]
        public string Contrasenia { get; set; }

        /*Se utilizara cuando se cree una nueva contraseña
         * la nueva contreseña no debe ser igual a la utlima usada*/
        [NotMapped]
        [StringLength(16)]
        public string UltimaContrasenia { get; set; }

        public List<Rol> Rol { get; set; }

        public Empleado Empleado { get; set; }
    }
}