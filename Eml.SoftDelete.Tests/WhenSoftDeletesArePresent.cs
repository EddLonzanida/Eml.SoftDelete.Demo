using Eml.SoftDelete.Data;
using Eml.SoftDelete.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.SoftDelete.Tests
{
    [TestFixture]
    public class WhenSoftDeletesArePresent : IntegrationTestBase
    {

        [Test]
        public void Entity_ShouldBeSoftDeleted()
        {
            const int ID = 1;
            const int ID2 = 2;
            var db = new DefaultDb();
            var item = db.Companies.Find(ID);
            var item2 = db.Companies.Find(ID2);

            db.Companies.Remove(item);
            db.Companies.Remove(item2);
            db.SaveChanges();

            var dbNoSoftDelete = new DefaultDbNoSoftDelete();
            var itemNoSoftDelete = dbNoSoftDelete.CompanyNoSoftDeletes.Find(ID);
            itemNoSoftDelete.ShouldNotBeNull();
            itemNoSoftDelete.DateDeleted.ShouldNotBeNull();

            var itemNoSoftDelete2 = dbNoSoftDelete.CompanyNoSoftDeletes.Find(ID2);
            itemNoSoftDelete2.ShouldNotBeNull();
            itemNoSoftDelete2.DateDeleted.ShouldNotBeNull();
        }

        [Test]
        public void Entity_ShouldBeUnqueryable()
        {
            const int ID = 1;
            const int ID2 = 2;

            var db = new DefaultDb();
            var item = db.Companies.Find(ID);
            var item2 = db.Companies.Find(ID2);


            db.Companies.Remove(item);
            db.Companies.Remove(item2);
            db.SaveChanges();

            var deletedItem = db.Companies.Find(ID);
            var deletedItem2 = db.Companies.Find(ID2);
            deletedItem.ShouldBeNull();
            deletedItem2.ShouldBeNull();
        }
    }
}
