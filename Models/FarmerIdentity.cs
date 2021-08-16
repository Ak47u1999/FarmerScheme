using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class FarmerIdentity
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public string PhoneNumber { get; set; }
        public string FarmerMailId { get; set; }
        public string BankAccNo { get; set; }
        public string BankIfsc { get; set; }
        public bool? DocumentStatus { get; set; }
        public string FarmerPassword { get; set; }
        public bool? AdminApprovalStatus { get; set; }
    }
}
