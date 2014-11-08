namespace AnimalHope.Data
{
    using AnimalHope.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<AnimalType> AnimalTypes
        {
            get
            {
                return this.GetRepository<AnimalType>();
            }
        }

        public IRepository<Condition> Conditions
        {
            get
            {
                return this.GetRepository<Condition>();
            }
        }

        public IRepository<Description> Descriptions
        {
            get
            {
                return this.GetRepository<Description>();
            }
        }

        public IRepository<Location> Locations
        {
            get
            {
                return this.GetRepository<Location>();
            }
        }

        public IRepository<Donation> Donations
        {
            get
            {
                return this.GetRepository<Donation>();
            }
        }

        public IRepository<Vet> Vets
        {
            get
            {
                return this.GetRepository<Vet>();
            }
        }

        public IRepository<Animal> Animals
        {
            get
            {
                return this.GetRepository<Animal>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
