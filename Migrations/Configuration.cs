namespace allpax_sale_miner.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<allpax_sale_miner.Models.allpax_sale_minerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "allpax_sale_miner.Models.allpax_sale_minerEntities";
        }

        protected override void Seed(allpax_sale_miner.Models.allpax_sale_minerEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
