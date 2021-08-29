using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Controllers
{
    public class AdminController : Controller
    {

        private readonly Web1209Context _db;
        public AdminController(Web1209Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult listUser()
        { 
            List<User> user = _db.Users.Where(x => x.Role.Equals("User") && x.Status.Equals(true)).ToList();
            return View(user);
        }
        //[HttpGet]
        //public IActionResult listEditor()
        //{
        //    List<User> user = _db.Users.Where(x => x.Role.Equals("Editor")).ToList();
        //    return View(user);
        //}
        //public IActionResult createUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult createUser(From user)
        //{
        //    UserManager UM = new UserManager(_db);
        //    if(UM.checkEmail(user.Email) && UM.checkUserName(user.UserName))
        //    {
        //        User u = new User();
        //        u.Name = user.Name;
        //        u.Email = user.Email;
        //        u.Role = "User";
        //        u.UserName = user.UserName;
        //        u.Password = user.Password;
        //        u.Status = true;
        //        u.Datejoin = DateTime.Now.ToString();
        //        _db.Users.Add(u);
        //        _db.SaveChanges();
        //    }
        //    return RedirectToAction("listUser", "Admin");
        //}

        public IActionResult delete(int ID)
        {
            if(ID == 0)
            {
                return NotFound();
            }
            var u = _db.Users.Find(ID);
            if(u == null)
            {
                return NotFound();
            }
            else
            {
                return View(u);
            }
        }

        [HttpPost]
        public IActionResult delete(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("listUser", "Admin");
        }
        public IActionResult update(int ID)
        {
            if(ID == 0)
            {
                return NotFound();
            }
            var u = _db.Users.Find(ID);
            if(u == null)
            {
                return NotFound();
            }
            else
            {
                return View(u);
            }
        }
        [HttpPost]
        public IActionResult update(User user , int ID)
        {
            UserManager UM = new UserManager(_db);
            if (UM.checkEmail(user.Email) && UM.checkUserName(user.UserName))
            {
                var u = _db.Users.Find(ID);
                u.Name = user.Name;
                u.Email = user.Email;
                u.UserName = user.UserName;
                _db.Users.Update(u);
                _db.SaveChanges();
                return RedirectToAction("listUser", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

       public IActionResult blockUser(int ID)
        {
            var user = _db.Users.Find(ID);
            user.Status = false;
            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("listBlock", "Admin");
        }

        public IActionResult unBlockUser(int ID)
        {
            var user = _db.Users.Find(ID);
            user.Status = true;
            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("listUser", "Admin");
        }
        public IActionResult listBlock()
        {
            List<User> user = _db.Users.Where(x => x.Status.Equals(false)).ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult searchByName(string name)
        {
            UserManager UM = new UserManager(_db);
            List<User> user = UM.search(name);
            return View(user);
        }              
        public IActionResult showProfile(int ID)
        {
            Profile profile = _db.Profiles.FirstOrDefault(x => x.IdUser.Equals(ID));
            User user = _db.Users.Find(ID);
            profile.IdUserNavigation = user;
            return View(profile);
        }

        public IActionResult showReceipt(int ID)
        {
            Receipt R = _db.Receipts.FirstOrDefault(x => x.IdUser.Equals(ID));
            User user = _db.Users.Find(ID);
            R.IdUserNavigation = user;
            return View(R);
        }


    }
}
