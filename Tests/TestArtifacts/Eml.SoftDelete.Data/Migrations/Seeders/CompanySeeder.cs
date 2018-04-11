using System.Data.Entity.Migrations;
using Eml.DataRepository;
using Eml.DataRepository.Extensions;
using Eml.SoftDelete.Data.Entities;

namespace Eml.SoftDelete.Data.Migrations.Seeders
{
    public static class CompanySeeder
    {
        public static void Seed(TestDb context)
        {
            Seeder.Execute("Companies", () =>
            {
                context.Companies.AddOrUpdate(r => r.Id,
                    new Company { Id = 1, Name = "Company01", Description = "Description01" },
                    new Company { Id = 2, Name = "Company02", Description = "Description02" }
                );

                context.DoSave("Companies");
            });
        }
    }
}