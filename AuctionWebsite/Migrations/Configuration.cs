namespace AuctionWebsite.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionWebsite.Models.ApplicationDbContext context)
        {
            var items = new Item[]
            {
                new Item { Name = "Leather Couch", IsActive = true, MinBid = 100m, Description = "A comfy leather couch" },
                new Item { Name = "Horse Statue", IsActive = true, MinBid = 50m, Description = "A horse statue from Turkey" },
                new Item { Name = "Vinyl Collection", IsActive = true, MinBid = 200m, Description = "Vinyl collection of 70s records" }
            };

            context.Items.AddOrUpdate(i => i.Name, items);
        }
    }
}
