namespace HandIn2._2_Relation_Database.Application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HandIn2._2_Relation_Database.Application.PersonKartotekContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HandIn2._2_Relation_Database.Application.PersonKartotekContext";
        }

        protected override void Seed(HandIn2._2_Relation_Database.Application.PersonKartotekContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
