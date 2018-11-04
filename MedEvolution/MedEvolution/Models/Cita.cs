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
    [Table("Cita")]
    public class Cita : IValidatableObject
    {
        public Cita()
        {
            FechaCreada = DateTime.Now;
        }

        [Key]
        [DisplayName("Id")]
        public int IdCita { get; set; }
       
        [Required]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy 0:HH:mm:ss}")]
        public DateTime FechaCreada { get; set; }


        [Required(ErrorMessage ="La Fecha no debe ser inferior a la fecha acutal")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MMM/ yyyy}")]
        [Remote("FechaParaCita", "Validaciones", ErrorMessage ="La fecha de la cita no puede ser inferior al día de hoy")]
        [DisplayName("Fecha de Cita")]
        public DateTime FechaCita { get; set; }

        [Required]
        [Column("HoraCita")]
        [DisplayName("Hora de la cita:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string HoraCita { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Causa")]
        public string Causa { get; set; }

        //[Remote("ObteberListadoMedico","FiltrosController")]
        public Medico Medico { get; set; }

        public Paciente Paciente { get; set; }

        public Estado Estado { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();

           if (FechaCita < DateTime.Today)
            {
                errores.Add(new ValidationResult("La fecha programada para la cita no debe ser inferior a la fecha actual", new string[] { "FechaCita" }));
            }

            return errores;
        }
    }
}