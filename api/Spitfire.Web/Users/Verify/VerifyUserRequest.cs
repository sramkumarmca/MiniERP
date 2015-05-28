namespace Spitfire.Web.Users.Verify
{
    using MediatR;

    public class VerifyUserRequest : IRequest<VerifyUserResponse>
    {
        public string Name { get; set; }
    }
}
