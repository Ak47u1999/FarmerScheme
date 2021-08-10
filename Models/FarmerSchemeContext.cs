using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmerScheme.Models
{
    public partial class FarmerSchemeContext : DbContext
    {
        public FarmerSchemeContext()
        {
        }

        public FarmerSchemeContext(DbContextOptions<FarmerSchemeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BidderAddress> BidderAddress { get; set; }
        public virtual DbSet<BidderIdentity> BidderIdentity { get; set; }
        public virtual DbSet<CropInfo> CropInfo { get; set; }
        public virtual DbSet<FarmerAddress> FarmerAddress { get; set; }
        public virtual DbSet<FarmerIdentity> FarmerIdentity { get; set; }
        public virtual DbSet<FarmerSoldHistory> FarmerSoldHistory { get; set; }
        public virtual DbSet<InsuranceApplication> InsuranceApplication { get; set; }
        public virtual DbSet<InsuranceClaim> InsuranceClaim { get; set; }
        public virtual DbSet<MarketplaceCrops> MarketplaceCrops { get; set; }
        public virtual DbSet<MarketplaceTransactions> MarketplaceTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=FarmerScheme;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BidderAddress>(entity =>
            {
                entity.HasKey(e => e.BidderId)
                    .HasName("PK__bidder_a__4C9C3BF5E861E620");

                entity.ToTable("bidder_address");

                entity.Property(e => e.BidderId)
                    .HasColumnName("bidder_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BidderAddress1)
                    .HasColumnName("bidder_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BidderCity)
                    .HasColumnName("bidder_city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidderPincode)
                    .HasColumnName("bidder_pincode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BidderState)
                    .HasColumnName("bidder_state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bidder)
                    .WithOne(p => p.BidderAddress)
                    .HasForeignKey<BidderAddress>(d => d.BidderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bidder_ad__bidde__4AB81AF0");
            });

            modelBuilder.Entity<BidderIdentity>(entity =>
            {
                entity.HasKey(e => e.BidderId)
                    .HasName("PK__bidder_i__4C9C3BF576246229");

                entity.ToTable("bidder_identity");

                entity.HasIndex(e => e.BidderBankAccNo)
                    .HasName("UQ__bidder_i__99AE6B0A20C0810E")
                    .IsUnique();

                entity.HasIndex(e => e.BidderMailId)
                    .HasName("UQ__bidder_i__39CE574D833E9D34")
                    .IsUnique();

                entity.HasIndex(e => e.BidderPassword)
                    .HasName("UQ__bidder_i__1C1BB72086ECF55A")
                    .IsUnique();

                entity.HasIndex(e => e.BidderPhoneNumber)
                    .HasName("UQ__bidder_i__8CC142A0AF0EE81F")
                    .IsUnique();

                entity.Property(e => e.BidderId)
                    .HasColumnName("bidder_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BidderAdminApprovalStatus)
                    .HasColumnName("bidder_admin_approval_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BidderBankAccNo)
                    .HasColumnName("bidder_bank_acc_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BidderBankIfsc)
                    .HasColumnName("bidder_bank_ifsc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidderDocumentStatus).HasColumnName("bidder_document_status");

                entity.Property(e => e.BidderMailId)
                    .HasColumnName("bidder_mail_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidderName)
                    .HasColumnName("bidder_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidderPassword)
                    .HasColumnName("bidder_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidderPhoneNumber)
                    .HasColumnName("bidder_phone_number")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CropInfo>(entity =>
            {
                entity.HasKey(e => e.CropType)
                    .HasName("PK__crop_inf__88B95E46E1BED39D");

                entity.ToTable("crop_info");

                entity.Property(e => e.CropType)
                    .HasColumnName("crop_type")
                    .ValueGeneratedNever();

                entity.Property(e => e.BasePrice)
                    .HasColumnName("base_price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<FarmerAddress>(entity =>
            {
                entity.HasKey(e => e.FarmerId)
                    .HasName("PK__farmer_a__C615582506D71886");

                entity.ToTable("farmer_address");

                entity.Property(e => e.FarmerId)
                    .HasColumnName("farmer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FarmerAddress1)
                    .HasColumnName("farmer_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerCity)
                    .HasColumnName("farmer_city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerLandAddress)
                    .HasColumnName("farmer_land_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerLandAddressPinCode)
                    .HasColumnName("farmer_land_address_pin_code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerPincode)
                    .HasColumnName("farmer_pincode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerState)
                    .HasColumnName("farmer_state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Farmer)
                    .WithOne(p => p.FarmerAddress)
                    .HasForeignKey<FarmerAddress>(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farmer_ad__farme__3E52440B");
            });

            modelBuilder.Entity<FarmerIdentity>(entity =>
            {
                entity.HasKey(e => e.FarmerId)
                    .HasName("PK__farmer_i__C6155825AFED8436");

                entity.ToTable("farmer_identity");

                entity.HasIndex(e => e.BankAccNo)
                    .HasName("UQ__farmer_i__122233933687792A")
                    .IsUnique();

                entity.HasIndex(e => e.FarmerMailId)
                    .HasName("UQ__farmer_i__6171E695F0CBC386")
                    .IsUnique();

                entity.HasIndex(e => e.FarmerPassword)
                    .HasName("UQ__farmer_i__D52E9086A9D1D132")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__farmer_i__A1936A6BCCDABD3A")
                    .IsUnique();

                entity.Property(e => e.FarmerId)
                    .HasColumnName("farmer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminApprovalStatus)
                    .HasColumnName("admin_approval_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BankAccNo)
                    .HasColumnName("bank_acc_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BankIfsc)
                    .HasColumnName("bank_ifsc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropName)
                    .HasColumnName("crop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasColumnName("crop_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentStatus).HasColumnName("document_status");

                entity.Property(e => e.FarmerMailId)
                    .HasColumnName("farmer_mail_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerName)
                    .HasColumnName("farmer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerPassword)
                    .HasColumnName("farmer_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FarmerSoldHistory>(entity =>
            {
                entity.HasKey(e => e.FarmerId)
                    .HasName("PK__farmer_s__C6155825406AF81C");

                entity.ToTable("farmer_sold_history");

                entity.Property(e => e.FarmerId)
                    .HasColumnName("farmer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CropName)
                    .HasColumnName("crop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Msp)
                    .HasColumnName("msp")
                    .HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SoldDate)
                    .HasColumnName("sold_date")
                    .HasColumnType("date");

                entity.Property(e => e.SoldPrice)
                    .HasColumnName("sold_price")
                    .HasColumnType("money");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.Farmer)
                    .WithOne(p => p.FarmerSoldHistory)
                    .HasForeignKey<FarmerSoldHistory>(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farmer_so__farme__412EB0B6");
            });

            modelBuilder.Entity<InsuranceApplication>(entity =>
            {
                entity.HasKey(e => e.PolicyNo)
                    .HasName("PK__insuranc__47DA175078617211");

                entity.ToTable("insurance_application");

                entity.Property(e => e.PolicyNo)
                    .HasColumnName("policy_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.CropName)
                    .HasColumnName("crop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("farmer_id");

                entity.Property(e => e.InsuranceCompany)
                    .HasColumnName("insurance_company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumAmount)
                    .HasColumnName("premium_amount")
                    .HasColumnType("money");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SumInsuredPerHecter)
                    .HasColumnName("sum_insured_per_hecter")
                    .HasColumnType("money");

                entity.Property(e => e.TotalSumInsured).HasColumnName("total_sum_insured");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.InsuranceApplication)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__insurance__farme__4D94879B");
            });

            modelBuilder.Entity<InsuranceClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK__insuranc__F9CC0896A9D99D3F");

                entity.ToTable("insurance_claim");

                entity.Property(e => e.ClaimId)
                    .HasColumnName("claim_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CauseOfLoss)
                    .HasColumnName("cause_of_loss")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimStatus).HasColumnName("claim_status");

                entity.Property(e => e.DateOfLoss)
                    .HasColumnName("date_of_loss")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfRequest)
                    .HasColumnName("date_of_request")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyNo).HasColumnName("policy_no");

                entity.HasOne(d => d.PolicyNoNavigation)
                    .WithMany(p => p.InsuranceClaim)
                    .HasForeignKey(d => d.PolicyNo)
                    .HasConstraintName("FK__insurance__polic__5070F446");
            });

            modelBuilder.Entity<MarketplaceCrops>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__marketpl__18D3B90F9F211C5A");

                entity.ToTable("marketplace_crops");

                entity.Property(e => e.RequestId)
                    .HasColumnName("request_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CropName)
                    .HasColumnName("crop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasColumnName("crop_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("farmer_id");

                entity.Property(e => e.FertilizerType)
                    .HasColumnName("fertilizer_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsTransactionCompleted)
                    .HasColumnName("isTransactionCompleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PostedDate)
                    .HasColumnName("posted_date")
                    .HasColumnType("date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.MarketplaceCrops)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__marketpla__farme__534D60F1");
            });

            modelBuilder.Entity<MarketplaceTransactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__marketpl__85C600AF4A1702C0");

                entity.ToTable("marketplace_transactions");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BidAdminApprovalStatus)
                    .HasColumnName("bid_admin_approval_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BidAmount)
                    .HasColumnName("bid_amount")
                    .HasColumnType("money");

                entity.Property(e => e.BidDate)
                    .HasColumnName("bid_date")
                    .HasColumnType("date");

                entity.Property(e => e.BidderId).HasColumnName("bidder_id");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.MarketplaceTransactions)
                    .HasForeignKey(d => d.BidderId)
                    .HasConstraintName("FK__marketpla__bidde__59FA5E80");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.MarketplaceTransactions)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__marketpla__reque__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
