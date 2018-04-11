using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Eml.SoftDelete.Data
{
    public class TestDbSoftDelete : TestDb
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var softDeleteColumnConvention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                SoftDeleteColumn.Key, (type, attributes) => attributes.Single().SoftDeleteColumnName);

            modelBuilder.Conventions.Add(softDeleteColumnConvention);

            base.OnModelCreating(modelBuilder);
        }
    }
}
