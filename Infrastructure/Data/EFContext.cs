using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public DbSet<Domain.Entities.User> Users { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
        : base(options) 
        {
        }
    }
}
