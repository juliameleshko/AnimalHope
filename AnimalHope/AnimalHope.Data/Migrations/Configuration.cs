namespace AnimalHope.Data.Migrations
{
    using AnimalHope.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            this.SeedTypes(context);
            this.SeedConditions(context);

            context.SaveChanges();
        }

        private void SeedTypes(ApplicationDbContext context)
        {
            context.AnimalTypes.Add(new AnimalType
            {
                Name = "Cat"
            });

            context.AnimalTypes.Add(new AnimalType
            {
                Name = "Dog"
            });
        }

        private void SeedConditions(ApplicationDbContext context)
        {
            context.Conditions.Add(new Condition
            {
                Name = "Homeless"
            });
            context.Conditions.Add(new Condition
            {
                Name = "At vet's office"
            });
            context.Conditions.Add(new Condition
            {
                Name = "At temporary home"
            });
            context.Conditions.Add(new Condition
            {
                Name = "Adopted"
            });
        }
    }
}
