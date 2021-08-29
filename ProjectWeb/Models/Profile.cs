﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWeb.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Brithday { get; set; }
        public string Gender { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
