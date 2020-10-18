using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Infrastructures.Data.Contexts
{
    public class DefaultDbContext : DbContext, IDefaultDbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected DefaultDbContext()
        {
            Database.Migrate();
        }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
