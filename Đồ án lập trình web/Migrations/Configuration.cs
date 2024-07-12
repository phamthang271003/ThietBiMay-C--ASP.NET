namespace Đồ_án_lập_trình_web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Đồ_án_lập_trình_web.Models.CompanyDBConText>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Đồ_án_lập_trình_web.Models.CompanyDBConText";
        }

        protected override void Seed(Đồ_án_lập_trình_web.Models.CompanyDBConText context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
