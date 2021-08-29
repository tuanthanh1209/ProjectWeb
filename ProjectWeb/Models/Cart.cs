using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWeb.Models
{
    public partial class Cart
    {
        public Cart()
        {
            DetailCarts = new HashSet<DetailCart>();
        }

        public int Id { get; set; }
        public int TotalMoney { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DetailCart> DetailCarts { get; set; }
    }
}
