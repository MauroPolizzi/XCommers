using XCommerce.AccesoDatos;

namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XCommerce.AccesoDatos.ModeloDatosContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XCommerce.AccesoDatos.ModeloDatosContainer context)
        {

        }
    }
}
