namespace AnimalHope.Data
{
    using System.Data.Entity;

    using AnimalHope.Data.Migrations;
    using AnimalHope.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<AnimalType> AnimalTypes { get; set; }

        public IDbSet<Condition> Conditions { get; set; }

        public IDbSet<Description> Descriptions { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Donation> Donations { get; set; }

        public IDbSet<Vet> Vets { get; set; }

        public IDbSet<Animal> Animals { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
