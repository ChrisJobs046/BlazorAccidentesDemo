using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Models
{
    public class Persona
    {
        [Key]
        public int PersonaId  { get; set; }
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }
        public int AccidenteId { get; set; }
        public Accidente Accidente { get; set; }
    }
}
