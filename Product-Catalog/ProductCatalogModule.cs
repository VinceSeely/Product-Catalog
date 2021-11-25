using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Product_Catalog.Services;
using System.Reflection;

namespace Product_Catalog
{
    internal class ProductCatalogModule : Autofac.Module
    {
        private IConfiguration _configuration;

        public ProductCatalogModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var optionsBuilder = new DbContextOptionsBuilder<ProductCatalogContext>();
            optionsBuilder.UseMySQL(_configuration.GetValue<string>("ConnectionString"));
            builder.RegisterInstance(optionsBuilder.Options).AsSelf();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductCatalogModule))).Where(p => p.Namespace.Contains("Services") && !p.IsInterface).AsImplementedInterfaces().SingleInstance();
        }
    }
}