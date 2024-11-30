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
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.MessageId);
                entity.HasOne(m => m.Sender).WithMany().HasForeignKey(m => m.SenderId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Receiver).WithMany().HasForeignKey(m => m.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);
                entity.HasOne(c => c.Customer).WithMany(c => c.Comments).HasForeignKey(m => m.CustomerId);

                entity.HasOne(c => c.Product).WithMany(c => c.Comments).HasForeignKey(m => m.ProductId);
            });
        }
    }
}
