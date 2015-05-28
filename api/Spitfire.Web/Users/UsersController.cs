namespace Spitfire.Web.Users
{
    using System;
    using System.Web.Http;
    using Create;
    using GNaP.WebApi.Versioning;
    using List;
    using MediatR;
    using Update;
    using View;

    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException("mediator");

            _mediator = mediator;
        }

        [VersionedRoute]
        public IHttpActionResult Get([FromUri] ListUsersRequest request)
        {
            return Ok(_mediator.Send(request ?? new ListUsersRequest()));
        }

        [VersionedRoute("{name}")]
        public IHttpActionResult Get([FromUri] ViewUserRequest request)
        {
            var user = _mediator.Send(request ?? new ViewUserRequest());

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [VersionedRoute]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Post([FromBody] CreateUserRequest request)
        {
            return Ok(_mediator.Send(request));
        }

        [VersionedRoute("{name}")]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Put(string name, [FromBody] UpdateUserRequest request)
        {
            request.OriginalName = name;
            return Ok(_mediator.Send(request));
        }
    }
}