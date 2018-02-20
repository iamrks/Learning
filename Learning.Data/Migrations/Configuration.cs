namespace Learning.Data.Migrations
{
    using Learning.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Learning.Data.LearningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Learning.Data.LearningContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Students.Count() == 0)
            {
                context.Students.AddOrUpdate(new Student()
                {
                    UserName = "trip",
                    FirstName = "Trip",
                    LastName = "Alexender",
                    Email = "trip@abc.com",
                    DateOfBirth = new DateTime(1980, 2, 15),
                    Address = "US"
                });
            }
        }
    }
}
