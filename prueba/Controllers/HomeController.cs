using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using prueba.Services;
using prueba.Models;

namespace prueba.Controllers
{
    public class HomeController : Controller
    {

        private InicioService ini;

        //public HomeController(IinicioService _servi)
        public HomeController()
        {
            this.ini = new InicioService();
        }

        public ActionResult Index()
        {
            var list = this.ini.ListProducts();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public async Task<JsonResult> getDatos()
        {
            var fff = "ffff";
            //var list = this.servicio.ListProducts();
            var list = this.ini.ListProducts();
            return Json(new { f = list }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Products Product = this.ini.GetProducts(Id);
            return View(Product);
        }

        [HttpPost]
        public ActionResult Edit(Products p)
        {
            var f = this.ini.EditarProduct(p);
            var list = this.ini.ListProducts();
            //return View("Index", list);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public JsonResult Pagar(Client client,List<Products> products)
        {
            var cli = client;
            var Lproducts = products;
            var ValorTotal = 0;
            Ventas ventas = new Ventas();
            this.ini.AddVentas(client,products);
            foreach(var i in Lproducts)
            {
                ValorTotal += i.ValorUnitario * i.Cantidad;
            }
            ventas.ListProducto = Lproducts;
            ventas.client = cli;
            ventas.ValorTotal = ValorTotal;
            return Json(new { f = ventas });
        }
        public ActionResult Clients()
        {
            List<Client> clients = this.ini.ListClients();
            return View(clients);
        }
        public ActionResult CliEdit(int Id)
        {
            var cli = this.ini.GetClient(Id);
            return View(cli);
        }
        [HttpPost]
        public ActionResult CliEdit(Client cli)
        {
            var f = this.ini.UpdateClient(cli);
            return RedirectToAction("Index","Home");
        }
    }
}