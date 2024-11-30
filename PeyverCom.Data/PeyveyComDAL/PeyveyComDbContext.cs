using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Data.PeyveyComDAL
{
    public class PeyverComDbContext :DbContext
    {
        public PeyverComDbContext(DbContextOptions<PeyverComDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasOne(c => c.Customer)
                        .WithMany(p => p.Products).HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Auction>().HasOne(a => a.Product)
                        .WithMany(p => p.Auctions).HasForeignKey(a => a.ProductId);
            modelBuilder.Entity<Offer>().HasOne(o => o.Auction)
                        .WithMany(a => a.Offers).HasForeignKey(o => o.AuctionId);
            modelBuilder.Entity<Offer>().HasOne(o => o.Customer)
                        .WithMany(c => c.Offers).HasForeignKey (o => o.CustomerId);
            modelBuilder.Entity<Sale>().HasOne( s => s.Auction)
                        .WithMany(a => a.Sales).HasForeignKey (s => s.AuctionId);
            modelBuilder.Entity<Sale>().HasOne(s => s.Offer)
                        .WithOne().HasForeignKey<Sale>(s => s.OfferId);
            modelBuilder.Entity<Sale>().HasOne(s => s.Customer)
                        .WithMany(c => c.Sales).HasForeignKey(s => s.CustomerId);    
            modelBuilder.Entity<CustomerProduct>().HasKey(cp => new
            { 
                cp.CustomerId,
                cp.ProductId 
            });
            modelBuilder.Entity<CustomerProduct>().HasOne(p => p.Customer)
                        .WithMany(c => c.CustomerProducts).HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<CustomerProduct>().HasOne(c => c.Product)
                        .WithMany( p => p.CustomerProducts).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                        .WithMany(c => c.Products).HasForeignKey (c => c.CategoryId);
            modelBuilder.Entity<CustomerSale>().HasKey(s => new
            {
                s.CustomerId,
                s.SaleId
            });
            modelBuilder.Entity<CustomerSale>().HasOne(s => s.Customer)
                        .WithMany(s => s.CustomerSales).HasForeignKey(s => s.CustomerId);
            modelBuilder.Entity<CustomerSale>().HasOne(s => s.Sale)
                      .WithMany(s => s.CustomerSales).HasForeignKey(s => s.SaleId);
        }
    }
}
