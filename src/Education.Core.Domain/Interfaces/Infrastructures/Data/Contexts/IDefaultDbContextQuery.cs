using Education.Core.Domain.Entities.Default;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface IDefaultDbContextQuery
    {
        public DbSet<Sample> Samples { get; set; }
    }
}
