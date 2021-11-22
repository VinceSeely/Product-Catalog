using Autofac;
using System.Reflection;

namespace Product_Catalog
{
    internal class ProductCatalogModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductCatalogModule))).Where(p => p.Namespace.Contains("Services") && !p.IsInterface).AsImplementedInterfaces().SingleInstance();
        }
    }
}