using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.Services
{
    public interface IinicioService
    {
        List<Products> ListProducts();
        Products GetProducts(int Id);

    }
}
