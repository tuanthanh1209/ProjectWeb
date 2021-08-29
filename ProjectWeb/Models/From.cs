using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Models
{
    public class From
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Datejoin { get; set; }
    }
    public class Add
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public string Images { get; set; }
        public int Stock { get; set; }
    }
    public class Login
    {
        [Required(ErrorMessage ="Enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
    public class Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Datejoin { get; set; }
    }

}
