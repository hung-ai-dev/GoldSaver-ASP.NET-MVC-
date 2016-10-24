using GoldSaver.Models;

namespace GoldSaver.Migrations
{
    using System;
    using System.IO;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoldSaver.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoldSaver.Models.ApplicationDbContext context)
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
            //
            string url = "E:\\[PJ] WebProject\\GoldSaver\\GoldSaver\\Content\\image\\categories";
            string[] filePaths = Directory.GetFiles(url);
            var i = 0;
            foreach (var item in filePaths)
            {
                var str = item.Split('\\');
                var name = str.Last().Split('.').First();

                context.Categories.AddOrUpdate(c => c.CategoryName,
                    new Models.Category()
                    {
                        CategoryName = name,
                        Link = "https://raw.githubusercontent.com/CNPMteam7/design/master/categories/icon/" + str.Last()
                    });
            }
        }
    }
}
