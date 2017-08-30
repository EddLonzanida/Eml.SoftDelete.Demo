using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Eml.SoftDelete.Data.Entities;

namespace Eml.SoftDelete.Data
{
    public class DefaultDb : DbContext
    {
        public DefaultDb() : base("DefaultConnectionString")
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var softDeleteColumnConvention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                SoftDeleteColumn.Key,
                (type, attributes) => attributes.Single().SoftDeleteColumnName);

            modelBuilder.Conventions.Add(softDeleteColumnConvention);
            base.OnModelCreating(modelBuilder);
        }
    }
}
