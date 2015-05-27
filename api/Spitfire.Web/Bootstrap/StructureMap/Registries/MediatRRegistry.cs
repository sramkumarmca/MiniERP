namespace Spitfire.Web.Bootstrap.StructureMap.Registries {
    using global::StructureMap.Configuration.DSL;
    using MediatR;
    using StructureMap;

    public class MediatRRegistry: Registry {
        public MediatRRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<IMediator>();
                scanner.AssemblyContainingType<DefaultContainer>();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof (IAsyncRequestHandler<,>));
                scanner.WithDefaultConventions();
            });
        }
    }
}