using System.Data.Entity;
using Eml.SoftDelete.Data.Entities;

namespace Eml.SoftDelete.Data
{
    public class DefaultDbNoSoftDelete : DbContext
    {
        public DefaultDbNoSoftDelete() : base("DefaultConnectionString")
        {
        }

        public DbSet<CompanyNoSoftDelete> CompanyNoSoftDeletes { get; set; } //Mapped to Companies table
    }
}
