using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class BidderAddress
    {
        public int BidderId { get; set; }
        public string BidderAddress1 { get; set; }
        public string BidderCity { get; set; }
        public string BidderState { get; set; }
        public string BidderPincode { get; set; }
    }
}
