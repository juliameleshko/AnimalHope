namespace AnimalHope.Data
{
    using AnimalHope.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IApplicationData
    {
        IRepository<AnimalType> AnimalTypes { get; }

        IRepository<Condition> Conditions { get; }

        IRepository<Description> Descriptions { get; }

        IRepository<Location> Locations { get; }

        IRepository<Donation> Donations { get; }

        IRepository<Vet> Vets { get; }

        IRepository<Animal> Animals { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}
