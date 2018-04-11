using System.Threading.Tasks;
using Eml.DataRepository.Contracts;
using Eml.SoftDelete.Data.Entities;
using Eml.SoftDelete.Tests.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.SoftDelete.Tests
{
    public class WhenSoftDelete : IntegrationTestDbBase
    {
        [Test]
        public async Task SoftDelete_ShouldUpdateCompany()
        {
            const int ID = 1;
            var dataRepositorySoftDeleteInt = classFactory.GetExport<IDataRepositorySoftDeleteInt<Company>>();
            var dataRepositoryInt = classFactory.GetExport<IDataRepositoryInt<Company>>();

            await dataRepositorySoftDeleteInt.DeleteAsync(ID, "Test");
            var resultAfterSoftDelete = await dataRepositorySoftDeleteInt.GetAsync(ID);
            var resultAfterNoSoftDelete = await dataRepositoryInt.GetAsync(ID);

            resultAfterSoftDelete.ShouldBeNull();
            resultAfterNoSoftDelete.ShouldNotBeNull();
            resultAfterNoSoftDelete.DeletionReason.ShouldBe("Test");
            resultAfterNoSoftDelete.DateDeleted.HasValue.ShouldBeTrue();
        }

        [Test]
        public async Task Delete_ShouldRemoveCompany()
        {
            const int ID = 2;
            var dataRepositorySoftDeleteInt = classFactory.GetExport<IDataRepositorySoftDeleteInt<Company>>();
            var dataRepositoryInt = classFactory.GetExport<IDataRepositoryInt<Company>>();

            await dataRepositoryInt.DeleteAsync(ID);
            var resultAfterSoftDelete = await dataRepositorySoftDeleteInt.GetAsync(ID);
            var resultAfterNoSoftDelete = await dataRepositoryInt.GetAsync(ID);

            resultAfterNoSoftDelete.ShouldBeNull();
            resultAfterSoftDelete.ShouldBeNull();
        }
    }
}