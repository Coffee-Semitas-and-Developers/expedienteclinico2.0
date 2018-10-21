using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedEvolution.Models
{
    public class OrdenExamen_Examen
    {
        public OrdenExamen_Examen()
        {
        }

        public OrdenExamen OrdenExamen { get; set; }
        public Examen Examen { get; set; }
    }
}