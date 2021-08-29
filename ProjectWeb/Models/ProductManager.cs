using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Models
{
    public class ProductManager
    {
        private readonly Web1209Context _db;

        public ProductManager(Web1209Context db)
        {
            _db = db;
        }
        public Product getID(int ID)
        {
            Product p = _db.Products.Find(ID);
            return p;
        }

        public List<Product> search(string name)
        {
            if (name == null || name == "")
            {
                return _db.Products.Where(x => x.Status.Equals(true)).ToList();
            }
            else
            {
                return _db.Products.Where(x => x.Name.Contains(name)&& x.Status.Equals(true)).ToList();
            }
        }

      
    }

}
