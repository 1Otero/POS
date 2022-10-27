using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public int Telefono { get; set; }
    }
}