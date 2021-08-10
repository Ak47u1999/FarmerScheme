using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class FarmerAddress
    {
        public int FarmerId { get; set; }
        public string FarmerAddress1 { get; set; }
        public string FarmerCity { get; set; }
        public string FarmerState { get; set; }
        public string FarmerPincode { get; set; }
        public string FarmerLandAddress { get; set; }
        public string FarmerLandAddressPinCode { get; set; }

        public virtual FarmerIdentity Farmer { get; set; }
    }
}
