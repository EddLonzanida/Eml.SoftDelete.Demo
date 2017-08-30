using Eml.SoftDelete.Data;
using Eml.SoftDelete.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.SoftDelete.Tests
{
    [TestFixture]
    public class WhenSoftDeleteIsPresent : IntegrationTestBase
    {

        [Test]
        public void Entity_ShouldBeSoftDeleted()
        {
            const int ID = 2;
            var db = new DefaultDb();
            var item = db.Companies.Find(ID);

            db.Companies.Remove(item);
            db.SaveChanges();

            var dbNoSoftDelete = new DefaultDbNoSoftDelete();
            var itemNoSoftDelete = dbNoSoftDelete.CompanyNoSoftDeletes.Find(ID);
            itemNoSoftDelete.ShouldNotBeNull();
            itemNoSoftDelete.DateDeleted.ShouldNotBeNull();
        }

        [Test]
        public void Entity_ShouldBeUnqueryable()
        {
            const int ID = 2;
            var db = new DefaultDb();
            var item = db.Companies.Find(ID);

            db.Companies.Remove(item);
            db.SaveChanges();

            var deletedItem = db.Companies.Find(ID);
            deletedItem.ShouldBeNull();
        }
    }
}
