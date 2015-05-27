namespace Spitfire.Web.Bootstrap.StructureMap {
    using global::StructureMap;
    using global::StructureMap.Configuration.DSL;
    using Microsoft.Practices.ServiceLocation;
    using Infrastructure;

    public class DefaultContainer : Container {
        public DefaultContainer()
        {
            var serviceLocator = new StructureMapServiceLocator(this);
            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);

            Configure(configuration => InitializeContainer(configuration, serviceLocatorProvider));
        }

        private static void InitializeContainer(IRegistry containerConfig, ServiceLocatorProvider serviceLocatorProvider)
        {
            containerConfig.Scan(scanner =>
            {
                scanner.AssemblyContainingType<DefaultContainer>();
                scanner.LookForRegistries();
            });
            containerConfig.For<ServiceLocatorProvider>().Use(serviceLocatorProvider);
        }
    }
}