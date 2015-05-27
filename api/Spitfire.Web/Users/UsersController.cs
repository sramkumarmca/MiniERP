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

        [VersionedRoute("{id:int:min(1)}")]
        public IHttpActionResult Get([FromUri] ViewUserRequest request)
        {
            return Ok(_mediator.Send(request ?? new ViewUserRequest()));
        }

        [VersionedRoute]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Post([FromBody] CreateUserRequest request)
        {
            return Ok(_mediator.Send(request));
        }

        [VersionedRoute("{id:int:min(1)}")]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Put(int id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            return Ok(_mediator.Send(request));
        }
    }
}