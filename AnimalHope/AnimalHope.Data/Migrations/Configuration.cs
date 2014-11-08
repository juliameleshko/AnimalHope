namespace AnimalHope.Data.Migrations
{
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
            //if (context.Users.Any())
            //{
            //    return;
            //}

            //    this.SeedCourses(context);
            //    this.SeedStudents(context);
        }

        //private void SeedStudents(StudentSystemDbContext context)
        //{
        //    if (context.Students.Any())
        //    {
        //        return;
        //    }

        //    context.Students.Add(new Student
        //    {
        //        FirstName = "Evlogi",
        //        LastName = "Hristov",
        //        Level = 1
        //    });

        //    context.Students.Add(new Student
        //    {
        //        FirstName = "Ivaylo",
        //        LastName = "Kenov",
        //        Level = 2,
        //    });

        //    context.Students.Add(new Student
        //    {
        //        FirstName = "Doncho",
        //        LastName = "Minkov",
        //        Level = 3
        //    });

        //    context.Students.Add(new Student
        //    {
        //        FirstName = "Nikolay",
        //        LastName = "Kostov",
        //        Level = 9999
        //    });
        //}

        //private void SeedCourses(StudentSystemDbContext context)
        //{
        //    if (context.Courses.Any())
        //    {
        //        return;
        //    }

        //    context.Courses.Add(new Course
        //    {
        //        Name = "Seeded course",
        //        Description = "Initial course for testing"
        //    });
        //}
    }
}
