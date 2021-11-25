using Autofac;
using Microsoft.EntityFrameworkCore;
using Product_Catalog.Services;
using System.Reflection;

namespace Product_Catalog
{
    internal class ProductCatalogModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var optionsBuilder = new DbContextOptionsBuilder<ProductCatalogContext>();
            optionsBuilder.UseMySQL(@"server=db,3306;user=root;password=Your_password123;database=product_catalog;");
            builder.RegisterInstance(optionsBuilder.Options).AsSelf();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductCatalogModule))).Where(p => p.Namespace.Contains("Services") && !p.IsInterface).AsImplementedInterfaces().SingleInstance();
        }
    }
}