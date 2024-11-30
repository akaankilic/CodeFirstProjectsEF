using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeyverCom.Data.PeyveyComDAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PeyverComDbContext>
    {
        public PeyverComDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PeyverComDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PeyverCom;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new PeyverComDbContext(optionsBuilder.Options);
        }
    }
}
