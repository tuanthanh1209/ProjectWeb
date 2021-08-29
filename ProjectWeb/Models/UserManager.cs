using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Models
{
    public class UserManager
    {
        private readonly Web1209Context _db;
        
        public UserManager(Web1209Context db)
        {
            _db = db;
        }

        public bool checkUserName(string username)
        {
            List<User> user = _db.Users.Where(x => x.UserName.Equals(username)).ToList();
            if(user.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkEmail(string email)
        {
            List<User> user = _db.Users.Where(x => x.Email.Equals(email)).ToList();
            if (user.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }     
        public string checkRole(string username)
        {            
            User user = _db.Users.FirstOrDefault(x => x.UserName.Equals(username));
            if (user.Role.Equals("User"))
            {
                return "User";
            }
            else if (user.Role.Equals("Admin"))
            {
                return "Admin";
            }
            else
            {
                return "Editor";
            }         
        }
        public List<User> search(string name)
        {
            if(name == null || name == "")
            {
                return _db.Users.Where(x => x.Role.Equals("User") && x.Status.Equals(true)).ToList();
            }
            else
            {
                return _db.Users.Where(x => x.Name.Contains(name) && x.Status.Equals(true) && x.Role.Equals("User")).ToList();
            }
        }        

        public Receipt getReceipt(int userID)
        {
            Receipt R = _db.Receipts.FirstOrDefault(x => x.IdUser.Equals(userID));
            User user = _db.Users.FirstOrDefault(x => x.Id.Equals(userID));

        }

    }
}
