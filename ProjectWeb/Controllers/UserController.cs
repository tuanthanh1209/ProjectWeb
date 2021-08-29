using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly Web1209Context _db;

        public UserController(Web1209Context db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login L)
        {
            
              UserManager UM = new UserManager(_db);
            if (ModelState.IsValid)
            {
                var check = _db.Users.Where(x => x.UserName.Equals(L.UserName) && x.Password.Equals(L.Password) && x.Status.Equals(true)).ToList();
                if (check.Count() > 0)
                {
                    HttpContext.Session.SetString("UserName", L.UserName);
                    if (UM.checkRole(L.UserName).Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (UM.checkRole(L.UserName).Equals("User"))
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Editor");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "Login Fail");
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register R)
        {
            UserManager UM = new UserManager(_db);
            if (UM.checkUserName(R.UserName) && UM.checkEmail(R.Email))
            {
                User u = new User();
                u.Name = R.Name;
                u.Email = R.Email;
                u.Role = "User";
                u.UserName = R.UserName;
                u.Password = R.Password;
                u.Status = true;
                u.Datejoin = DateTime.Now.ToString();
                _db.Users.Add(u);
                _db.SaveChanges();
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }
                
    }
}
