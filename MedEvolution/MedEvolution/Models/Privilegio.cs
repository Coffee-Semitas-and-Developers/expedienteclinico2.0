using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Privilegio")]
    public class Privilegio
    {
        /*Aun falta analisis aqui y mejor organizacion*/

        Privilegio()
        {
        }

        [Key]
        public int CodigoPrivilegio { get; set; }

        [Required]
        [StringLength(30)]
        public string NombrePrivilegio { get; set; }

        [Required]
        [StringLength(80)]
        public string Url { get; set; }

        [Required]
        public bool Leer { get; set; }

        [Required]
        public bool Borrar { get; set; }

        [Required]
        public bool Modificar { get; set; }

        [Required]
        public bool Escribir { get; set; }

    }
}