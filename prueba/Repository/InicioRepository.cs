using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace prueba.Repository
{
    public class InicioRepository : IinicioRepository
    {
        private readonly SqlConnection _sql;
        public InicioRepository()
        {
            this._sql = new SqlConnection(ConfigurationManager.ConnectionStrings["qa-prueba"].ConnectionString);
            //this._sql = new SqlConnection(Data Source = localhost; Initial Catalog = pruebas; User id = fff; Password = 1234);
        }
        public Products GetProduct(int Id)
        {
            var product = this._sql.Query<Products>("SELECT * FROM producto WHERE Id = " + Id).First();
            return product;
        }
        public Client GetClient(int Id)
        {
            var Cli = this._sql.Query<Client>("SELECT * FROM cliente WHERE Id = " + Id).First();
            return Cli;
        }
        public List<Products> ListProducts()
        {
            List<Products> Lisproducts = this._sql.Query<Products>("SELECT * FROM producto").ToList();
            return Lisproducts;
        }
        public List<Client> ListClients()
        {   
            List<Client> LisClients = this._sql.Query<Client>("SELECT * FROM cliente").ToList();
            return LisClients;
        }
        public string UpdateProduct(Products producto)
        {
            try
            {
                this._sql.Query($"UPDATE producto SET Producto='{producto.Producto}',Cantidad={producto.Cantidad},ValorUnitario={producto.ValorUnitario},ValorTotal={producto.ValorTotal} WHERE Id={producto.Id}");
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string UpdateClient(Client cli)
        {
            try
            {
                this._sql.Query($"UPDATE cliente SET Nombre='{cli.Nombre}',Apellido='{cli.Apellido}',Cedula={cli.Cedula},Telefono={cli.Telefono} WHERE Id={cli.Id}");
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string AddClient(Client client)
        {
            try
            {
                this._sql.Query($"INSERT INTO cliente (Nombre,Apellido,Cedula,Telefono) VALUES ('{client.Nombre}','{client.Apellido}',{client.Cedula},{client.Telefono})");
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string AddVentas(Client client, List<Products> products)
        {
            try
            {
                //var lengthProducts = this.ListProducts().Count + 1;
                this.AddClient(client);
                var cli = client;
                var lprod = products;
                var lengthClients = this.ListClients().Count;
                foreach (var i in products)
                {
                    this._sql.Query($"INSERT INTO ventas (IdProducto,IdCliente,Cantidad,ValorUnitario,ValorTotal) VALUES ({i.Id},{lengthClients},{i.Cantidad},{i.ValorUnitario},{i.ValorTotal})");
                }
                return "";
            }
            catch (Exception e) {
                throw e;
            }
            
        }
    }
}