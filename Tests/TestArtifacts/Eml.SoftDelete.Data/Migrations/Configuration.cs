using System;
using System.Data.Entity.Migrations;
using Eml.SoftDelete.Data.Migrations.Seeders;

namespace Eml.SoftDelete.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<TestDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestDb context)
        {
            Console.WriteLine("====== Seed start..");

            CompanySeeder.Seed(context);
        }
    }
}
