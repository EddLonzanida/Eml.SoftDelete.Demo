using System.Data.Entity.Migrations;
using Eml.SoftDelete.Data.Entities;

namespace Eml.SoftDelete.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<DefaultDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DefaultDb context)
        {
            context.Companies.AddOrUpdate(r => r.Id,
                new Company { Id = 1, Name = "Company01", Description = "Description01" },
                new Company { Id = 2, Name = "Company02", Description = "Description02" }
            );
            context.SaveChanges();
        }
    }
}
