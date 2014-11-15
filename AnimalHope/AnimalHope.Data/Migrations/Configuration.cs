namespace AnimalHope.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AnimalHope.Models;

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

            //this.SeedUsers(context);
            this.SeedTypes(context);
            this.SeedConditions(context);

            context.SaveChanges();
        }

        //private void SeedUsers(ApplicationDbContext context)
        //{
        //    context.Users.Add(new ApplicationUser
        //        {
        //            Email = "admin@admin.com",
        //            FirstName = "Admin",
        //            LastName = "Administrator",
        //            PhoneNumber = "0888123456",
        //            Roles = new 
        //        });
        //}

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
