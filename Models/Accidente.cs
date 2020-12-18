using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Models
{
    public class Accidente
    {
        [Key]
        public int AccidenteId { get; set; }
        public string Descripcion { get; set; }
        public string Imagenes { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Lugar { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<Persona> Personas { get; } = new List<Persona>();
    }

}
