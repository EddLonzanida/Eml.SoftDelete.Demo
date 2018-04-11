using System;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Exceptions;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using NUnit.Framework;

namespace Eml.SoftDelete.Tests.BaseClasses
{
    public class IntegrationTestDbBase
    {
        protected IClassFactory classFactory;

        private IMigrator dbMigrator;

        [OneTimeSetUp]
        public void Setup()
        {
            classFactory = Bootstrapper.Init();
            dbMigrator = classFactory.GetMigrator(Environments.INTEGRATIONTEST);

            if (dbMigrator == null)
            {
                throw new NotFoundException("dbMigrator not found..");
            }

            Console.WriteLine("DestroyDb if any..");
            dbMigrator.DestroyDb();

            Console.WriteLine("CreateDb..");
            dbMigrator.CreateDb();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            dbMigrator.DestroyDb();

            var container = classFactory.Container;
            classFactory = null;
            container.Dispose();
        }
    }
}
