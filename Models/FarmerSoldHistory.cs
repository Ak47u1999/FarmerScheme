using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class FarmerSoldHistory
    {
        public int FarmerId { get; set; }
        public DateTime? SoldDate { get; set; }
        public string CropName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Msp { get; set; }
        public decimal? SoldPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual FarmerIdentity Farmer { get; set; }
    }
}
