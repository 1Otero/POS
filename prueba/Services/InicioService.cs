using prueba.Models;
using prueba.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace prueba.Services
{
    public class InicioService : IinicioService
    {
        public InicioRepository _inicio;
        /*public InicioService()
        {

        }*/
        public InicioService()
        {
            _inicio = new InicioRepository();
        }
        public Products GetProducts(int Id)
        {
            return this._inicio.GetProduct(Id);
        }
        public Client GetClient(int Id)
        {
            return this._inicio.GetClient(Id);
        }
        public List<Products> ListProducts()
        {
            return this._inicio.ListProducts();
        }
        public List<Client> ListClients()
        {
            return this._inicio.ListClients();
        }
        public string EditarProduct(Products product)
        {
            return this._inicio.UpdateProduct(product);
        }
        public string UpdateClient(Client cli)
        {
            return this._inicio.UpdateClient(cli);
        }
        public string AddVentas(Client client, List<Products> products)
        {
            return this._inicio.AddVentas(client,products);
        }
        public string AddClient(Client client)
        {
            return this._inicio.AddClient(client);
        }
    }
}