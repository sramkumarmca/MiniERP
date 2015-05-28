namespace Spitfire.Web.Users.View
{
    using MediatR;

    public class ViewUserRequest : IRequest<ViewUserResponse>
    {
        public string Name { get; set; }
    }
}
