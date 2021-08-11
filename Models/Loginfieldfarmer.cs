using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class Loginfieldfarmer
    {
        public string Uname { get; set; }
        public string Password { get; set; }
        public bool? IsValid { get; set; }
    }
}
