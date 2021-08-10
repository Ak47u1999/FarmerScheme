using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class MarketplaceCrops
    {
        public MarketplaceCrops()
        {
            MarketplaceTransactions = new HashSet<MarketplaceTransactions>();
        }

        public int RequestId { get; set; }
        public int? FarmerId { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public string FertilizerType { get; set; }
        public long? Quantity { get; set; }
        public bool? IsTransactionCompleted { get; set; }
        public DateTime? PostedDate { get; set; }

        public virtual FarmerIdentity Farmer { get; set; }
        public virtual ICollection<MarketplaceTransactions> MarketplaceTransactions { get; set; }
    }
}
