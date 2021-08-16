using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class BidderIdentity
    {
        public int BidderId { get; set; }
        public string BidderName { get; set; }
        public string BidderPhoneNumber { get; set; }
        public string BidderMailId { get; set; }
        public string BidderBankAccNo { get; set; }
        public string BidderBankIfsc { get; set; }
        public bool? BidderDocumentStatus { get; set; }
        public string BidderPassword { get; set; }
        public bool? BidderAdminApprovalStatus { get; set; }
    }
}
