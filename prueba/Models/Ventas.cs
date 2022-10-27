using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Ventas
    {
        public int IdVenta;
        public List<Products> ListProducto;
        public Client client;
        public int ValorTotal;
    }
}