using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFFINAL
{
    public partial class EF : DbContext
    {
        public EF()
            : base("name=EF")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Warehouse> Product_Warehouse { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transfer_Products> Transfer_Products { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Clients)
                .Map(m => m.ToTable("Order").MapLeftKey("Client_Id").MapRightKey("Prod_Code"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MeasurementUnits)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Warehouse)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Transfer_Products)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Product_Warehouse)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Transfer_Products)
                .WithRequired(e => e.Warehouse)
                .HasForeignKey(e => e.Source_Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Transfer_Products1)
                .WithRequired(e => e.Warehouse1)
                .HasForeignKey(e => e.Destination_Warehouse)
                .WillCascadeOnDelete(false);
        }
    }
}
