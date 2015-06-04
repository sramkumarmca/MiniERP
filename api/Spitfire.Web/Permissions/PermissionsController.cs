namespace Spitfire.Web.Permissions
{
    using System;
    using System.Web.Http;
    using GNaP.WebApi.Versioning;
    using MediatR;

    [RoutePrefix("permissions")]
    public class PermissionsController : ApiController
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException("mediator");

            _mediator = mediator;
        }

        [VersionedRoute]
        public IHttpActionResult Get()
        {
            return Ok(User.Identity);
        }
    }
}