using System;
namespace AnimalHope.Data
{
    using AnimalHope.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext : IDisposable
    {
        IDbSet<AnimalType> AnimalTypes { get; set; }

        IDbSet<Condition> Conditions { get; set; }

        IDbSet<Description> Descriptions { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Donation> Donations { get; set; }

        IDbSet<Vet> Vets { get; set; }

        IDbSet<Animal> Animals { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
