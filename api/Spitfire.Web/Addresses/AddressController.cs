


namespace Spitfire.Web.Addresses
{

    using System;
    using System.Web.Http;
    using GNaP.WebApi.Versioning;
    using MediatR;
    using Spitfire.Web.Addresses.Create;

    [RoutePrefix("addresses")]
    public class AddressController : ApiController
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException("mediator");

            _mediator = mediator;
        }

        [VersionedRoute]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Post([FromBody] CreateAddressRequest request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}
