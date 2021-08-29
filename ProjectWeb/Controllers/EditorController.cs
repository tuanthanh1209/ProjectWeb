using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Controllers
{
    public class EditorController : Controller
    {
        private readonly Web1209Context _db;

        public EditorController (Web1209Context db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult listProduct()
        {
            List<Product> pro = _db.Products.Where(x => x.Status.Equals(true)).ToList();
            return View(pro);
        }
        public IActionResult createProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult createProduct(Add pro)
        {
            Product product = new Product();
            product.Name = pro.Name;
            product.Brand = pro.Brand;   
            product.Condition = pro.Condition;
            product.Size = pro.Size;
            product.Price = pro.Price;
            product.Status = true;
            product.Images = pro.Images;
            product.Stock = pro.Stock;
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("listProduct", "Editor");
        }
        public IActionResult update(int ID)
        {
            if(ID == 0)
            {
                return NotFound();
            }
            var pro = _db.Products.Find(ID);
            if(pro == null)
            {
                return NotFound();
            }
            else
            {
                return View(pro);
            }
        }
        [HttpPost]
        public IActionResult update(Product pro, int ID)
        {
            var p = _db.Products.Find(ID);
            p.Stock = pro.Stock;
            _db.Products.Update(p);
            _db.SaveChanges();
            return RedirectToAction("listProduct", "Editor");
        }
        public IActionResult delete(int ID)
        {
            if(ID == 0)
            {
                return NotFound();
            }
            var pro = _db.Products.Find(ID);
            if(pro == null)
            {
                return NotFound();
            }
            else
            {
                return View(pro);
            }
        }
        [HttpPost]
        public IActionResult delete(Product pro)
        {
            _db.Products.Remove(pro);
            _db.SaveChanges();
            return RedirectToAction("listProduct", "Editor");
        }
        public IActionResult serachProduct(string name)
        {
            ProductManager PM = new ProductManager(_db);
            List<Product> product = PM.search(name);
            return View(product);
        }
        public IActionResult blockPro(int ID)
        {
            var pro = _db.Products.Find(ID);
            if(pro.Stock == 0)
            {
                pro.Status = false;
                _db.Products.Update(pro);
                _db.SaveChanges();
            }
            return RedirectToAction("listProduct", "Editor");
        }
        public IActionResult unblockPro(int ID)
        {
            var pro = _db.Products.Find(ID);
            pro.Stock = 10;
            if (pro.Stock > 0)
            {                
                pro.Status = true;
                _db.Products.Update(pro);
                _db.SaveChanges();
            }
            return RedirectToAction("listProduct", "Editor");
        }
        public IActionResult listBlock(int ID)
        {         
            List<Product> p = _db.Products.Where(x => x.Status.Equals(false)).ToList();
            return View(p);
        }
        


    }    
}
