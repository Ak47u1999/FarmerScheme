using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class InsuranceClaim
    {
        public int ClaimId { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public int? PolicyNo { get; set; }
        public string CauseOfLoss { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public bool? ClaimStatus { get; set; }

        public virtual InsuranceApplication PolicyNoNavigation { get; set; }
    }
}
