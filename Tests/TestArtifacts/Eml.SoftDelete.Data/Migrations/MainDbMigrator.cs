using System.ComponentModel.Composition;
using Eml.ConfigParser;
using Eml.DataRepository;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;

namespace Eml.SoftDelete.Data.Migrations
{
    [DbMigratorExport(Environments.INTEGRATIONTEST)]
    public class MainDbMigrator : MigratorBase<TestDb, Configuration>
    {
        [ImportingConstructor]
        public MainDbMigrator(IConfigBase<string, MainDbConnectionString> mainDbConnectionString)
            : base(mainDbConnectionString.Value)
        {
        }
    }
}