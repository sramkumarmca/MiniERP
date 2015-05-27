namespace Spitfire.Web.Users.Create
{
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}
