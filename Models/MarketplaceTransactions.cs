using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class MarketplaceTransactions
    {
        public int TransactionId { get; set; }
        public int? RequestId { get; set; }
        public int? BidderId { get; set; }
        public decimal? BidAmount { get; set; }
        public DateTime? BidDate { get; set; }
        public bool? BidAdminApprovalStatus { get; set; }
    }
}
