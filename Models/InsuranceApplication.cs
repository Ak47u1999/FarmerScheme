using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class InsuranceApplication
    {
        public int PolicyNo { get; set; }
        public int? FarmerId { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal? SumInsuredPerHecter { get; set; }
        public decimal? PremiumAmount { get; set; }
        public string CropName { get; set; }
        public long? Area { get; set; }
        public long? TotalSumInsured { get; set; }
        public bool? Status { get; set; }
    }
}
