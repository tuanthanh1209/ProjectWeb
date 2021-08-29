using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWeb.Models
{
    public partial class DetailsReceipt
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int IdProduct { get; set; }
        public int IdReceipt { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Receipt IdReceiptNavigation { get; set; }
    }
}
