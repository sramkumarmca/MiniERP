namespace Spitfire.Web.Users
{
    using System;
    using System.Web.Http;
    using Create;
    using GNaP.WebApi.Versioning;
    using List;
    using MediatR;
    using Update;
    using Verify;
    using View;

    [Authorize]
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
            var user = _mediator.Send(request ?? new ViewUserRequest());

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [VersionedRoute("verify/{name}")]
        public IHttpActionResult GetVerify([FromUri] VerifyUserRequest request)
        {
            var verify = _mediator.Send(request ?? new VerifyUserRequest());

            if (verify == null)
                return NotFound();

            return Ok(verify);
        }

        [VersionedRoute]
        public IHttpActionResult Post([FromBody] CreateUserRequest request)
        {
            return Ok(_mediator.Send(request));
        }

        [VersionedRoute("{id:int:min(1)}")]
        public IHttpActionResult Put(int id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            return Ok(_mediator.Send(request));
        }
    }
}