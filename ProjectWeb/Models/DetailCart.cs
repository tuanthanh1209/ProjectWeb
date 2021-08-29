using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWeb.Models
{
    public partial class DetailCart
    {
        public int Id { get; set; }
        public int IdCart { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public virtual Cart IdCartNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
