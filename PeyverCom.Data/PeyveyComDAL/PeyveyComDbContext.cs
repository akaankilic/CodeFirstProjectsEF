using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Entities;

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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasOne(c => c.Customer)
                        .WithMany(p => p.Products).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Auction>().HasOne(a => a.Product)
                        .WithMany(p => p.Auctions).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Offer>().HasOne(o => o.Auction)
                        .WithMany(a => a.Offers).HasForeignKey(o => o.AuctionId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Offer>().HasOne(o => o.Customer)
                        .WithMany(c => c.Offers).HasForeignKey (o => o.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sale>().HasOne( s => s.Auction)
                        .WithMany(a => a.Sales).HasForeignKey (s => s.AuctionId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sale>().HasOne(s => s.Offer)
                        .WithOne().HasForeignKey<Sale>(s => s.OfferId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sale>().HasOne(s => s.Customer)
                        .WithMany(c => c.Sales).HasForeignKey(s => s.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.MessageId);
                entity.HasOne(m => m.Sender).WithMany().HasForeignKey(m => m.SenderId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Receiver).WithMany().HasForeignKey(m => m.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);
                entity.HasOne(c => c.Customer).WithMany(c => c.Comments).HasForeignKey(m => m.CustomerId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Product).WithMany(c => c.Comments).HasForeignKey(m => m.ProductId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CustomerProduct>().HasNoKey();
            modelBuilder.Entity<CustomerSale>().HasOne(cs => cs.Sale)
                        .WithMany(s => s.CustomerSales).HasForeignKey(cs => cs.SaleId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CustomerSale>().HasKey(cs => cs.Id);
            modelBuilder.Entity<Customer>().HasMany(c => c.Products)
                        .WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Offers)
                        .WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Customer>().Property(p => p.PasswordHash).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.PasswordSalt).IsRequired();

        }
    }
}
