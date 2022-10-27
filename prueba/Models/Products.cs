using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }
        public int ValorTotal { get; set; }
    }
}