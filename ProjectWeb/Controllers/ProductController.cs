using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly Web1209Context _db;
        public ProductController(Web1209Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> lstProduct = _db.Products.ToList();
            return View(lstProduct);
        }

        public IActionResult Details(int id)
        {
            ProductManager PM = new ProductManager(_db);
            Product p = PM.getID(id);
            return View(p);
        }
       

    }
}
