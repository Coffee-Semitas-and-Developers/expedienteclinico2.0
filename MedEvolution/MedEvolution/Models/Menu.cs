using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    [Table("Menu")]
    public class Menu
    {
        /*Aun falta analisis aqui y mejor organizacion*/

        [Key]
        public int CodigoMenu { get; set; }

        public int? Men_codigoMenu { get; set; }

        [Required]
        [Description("Menú:")]
        [StringLength(15)]
        public string NombreMenu { get; set; }

    }
}