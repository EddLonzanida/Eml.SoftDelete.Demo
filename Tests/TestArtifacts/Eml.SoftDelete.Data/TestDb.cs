using System.Data.Entity;
using Eml.SoftDelete.Data.Entities;

namespace Eml.SoftDelete.Data
{
    public class TestDb : DbContext
    {
        public const string CONNECTION_STRING = "MainDbConnectionString";

        public TestDb() : base(CONNECTION_STRING)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}