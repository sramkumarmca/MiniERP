namespace Spitfire.Web.Bootstrap.StructureMap.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using global::StructureMap;

    internal class ServiceActivator : IHttpControllerActivator
    {
        private readonly Container _container;

        public ServiceActivator(Container container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_container.GetInstance(controllerType);
        }
    }
}