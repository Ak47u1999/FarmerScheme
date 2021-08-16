using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerScheme.Models
{
    public class BidderViewModel
    {
        public BidderViewModel(int requestId, string bidderName, decimal? bidAmount, DateTime? bidDate, bool? bidAdminApprovalStatus)
        {
            this.requestId = requestId;
            this.bidderName = bidderName;
            BidAmount = bidAmount;
            BidDate = bidDate;
            BidAdminApprovalStatus = bidAdminApprovalStatus;
        }

        public BidderViewModel() { }

        public int? requestId { get; set; }
        public string bidderName { get; set; }
        public decimal? BidAmount { get; set; }
        public DateTime? BidDate { get; set; }
        public bool? BidAdminApprovalStatus { get; set; }
    }
}
