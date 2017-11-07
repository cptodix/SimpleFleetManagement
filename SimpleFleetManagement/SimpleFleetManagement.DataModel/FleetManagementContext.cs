namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FleetManagementContext : DbContext
    {
        public FleetManagementContext()
            : base("name=FleetManagementContext")
        {
        }

        public virtual DbSet<MstCrew> MstCrews { get; set; }
        public virtual DbSet<MstCustomer> MstCustomers { get; set; }
        public virtual DbSet<MstFleet> MstFleets { get; set; }
        public virtual DbSet<MstKaroseri> MstKaroseris { get; set; }
        public virtual DbSet<MstMerkBu> MstMerkBus { get; set; }
        public virtual DbSet<MstPart> MstParts { get; set; }
        public virtual DbSet<MstService> MstServices { get; set; }
        public virtual DbSet<MstTypeBu> MstTypeBus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstCrew>()
                .Property(e => e.CrewId)
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.CrewName)
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.DrivingLicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.PlaceOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MstCrew>()
                .Property(e => e.Role)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.CustomerId)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.OrganizationName)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.CustomerAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.OrganizationAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.IdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.CustomerPhone)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.OrganizationPhone)
                .IsUnicode(false);

            modelBuilder.Entity<MstCustomer>()
                .Property(e => e.OrganizationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<MstFleet>()
                .Property(e => e.FleetId)
                .IsUnicode(false);

            modelBuilder.Entity<MstFleet>()
                .Property(e => e.TypeId)
                .IsUnicode(false);

            modelBuilder.Entity<MstFleet>()
                .Property(e => e.LicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MstFleet>()
                .Property(e => e.Karoseri)
                .IsUnicode(false);

            modelBuilder.Entity<MstKaroseri>()
                .Property(e => e.KaroseriId)
                .IsUnicode(false);

            modelBuilder.Entity<MstKaroseri>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MstKaroseri>()
                .HasMany(e => e.MstFleets)
                .WithRequired(e => e.MstKaroseri)
                .HasForeignKey(e => e.Karoseri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MstMerkBu>()
                .Property(e => e.MerkId)
                .IsUnicode(false);

            modelBuilder.Entity<MstMerkBu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MstMerkBu>()
                .HasMany(e => e.MstTypeBus)
                .WithRequired(e => e.MstMerkBu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MstPart>()
                .Property(e => e.PartId)
                .IsUnicode(false);

            modelBuilder.Entity<MstPart>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MstPart>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MstService>()
                .Property(e => e.ServiceId)
                .IsUnicode(false);

            modelBuilder.Entity<MstService>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MstTypeBu>()
                .Property(e => e.TypeId)
                .IsUnicode(false);

            modelBuilder.Entity<MstTypeBu>()
                .Property(e => e.MerkId)
                .IsUnicode(false);

            modelBuilder.Entity<MstTypeBu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MstTypeBu>()
                .HasMany(e => e.MstFleets)
                .WithRequired(e => e.MstTypeBu)
                .WillCascadeOnDelete(false);
        }
    }
}
