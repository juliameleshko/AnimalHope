namespace AnimalHope.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AnimalHope.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

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

            this.SeedRole(context, "Admin");
            this.SeedRole(context, "User");

            this.SeedAdmin(context, "admin@admin.admin", "123456");
            this.SeedUser(context, "user@user.user", "123456");
            
            this.SeedTypes(context);
            this.SeedConditions(context);

            context.SaveChanges();
        }

        private void SeedRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        private void SeedAdmin(ApplicationDbContext context, string username, string password)
        {
            var admin = new ApplicationUser()
            {
                UserName = username,
                Email = username,
                FirstName = "Admin",
                LastName = "Administrator",
                PhoneNumber = "0888123456"
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!userManager.Users.Any(u => u.UserName == username))
            {
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, "Admin");
            }
        }

        private void SeedUser(ApplicationDbContext context, string username, string password)
        {
            var admin = new ApplicationUser()
            {
                UserName = username,
                Email = username,
                FirstName = "User",
                LastName = "AppUser",
                PhoneNumber = "0888654321"
            };

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!userManager.Users.Any(u => u.UserName == username))
            {
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, "User");
            }
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
