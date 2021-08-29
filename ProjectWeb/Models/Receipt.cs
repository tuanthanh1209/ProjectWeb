using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWeb.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            DetailsReceipts = new HashSet<DetailsReceipt>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DetailsReceipt> DetailsReceipts { get; set; }
    }
}
