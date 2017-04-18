namespace Resto.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Resto.Models.BddContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Resto.Models.BddContext";
        }

        protected override void Seed(Resto.Models.BddContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.Restos.AddOrUpdate(new Resto.Models.Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0102030405" });
            context.Restos.AddOrUpdate(new Resto.Models.Resto { Id = 2, Nom = "Resto pinière", Telephone = "0102030405" });
            context.Restos.AddOrUpdate(new Resto.Models.Resto { Id = 3, Nom = "Resto toros", Telephone = "0102030405" });
            context.Utilisateurs.AddOrUpdate(new Models.Utilisateur { Id = 1, Password = "123", Prenom = "Eric" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
