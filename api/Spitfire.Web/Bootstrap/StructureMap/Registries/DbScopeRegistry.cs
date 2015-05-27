namespace Spitfire.Web.Bootstrap.StructureMap.Registries
{
    using System;
    using global::StructureMap.Configuration.DSL;
    using global::StructureMap.Graph;
    using global::StructureMap.TypeRules;
    using GNaP.Data.Scope.EntityFramework.Implementation;
    using GNaP.Data.Scope.EntityFramework.Interfaces;

    public class DbScopeRegistry : Registry
    {
        public DbScopeRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<IDbScopeFactory>();
                scanner.AssemblyContainingType<EntityFrameworkScopeFactory>();
                scanner.Convention<AllInterfacesConvention>();
            });

            For<IDbScopeFactory>().Use<IDbScopeFactory>(() => null);
        }

        private class AllInterfacesConvention : IRegistrationConvention
        {
            public void Process(Type type, Registry registry)
            {
                // Only work on concrete types
                if (!type.IsConcrete() || type.IsGenericType || type.IsEnum)
                    return;

                // Register against all the interfaces implemented
                // by this concrete class
                foreach (var @interface in type.GetInterfaces())
                    registry.For(@interface).Use(type);
            }
        }
    }
}