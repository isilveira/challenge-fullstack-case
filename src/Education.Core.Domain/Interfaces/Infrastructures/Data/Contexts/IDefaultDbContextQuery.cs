using Education.Core.Domain.Entities.Default;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface IDefaultDbContextQuery
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
