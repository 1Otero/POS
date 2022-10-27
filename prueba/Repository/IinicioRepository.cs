using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.Repository
{
    public interface IinicioRepository
    {

        List<Products> ListProducts();
        Products GetProduct(int Id);
    }
}
