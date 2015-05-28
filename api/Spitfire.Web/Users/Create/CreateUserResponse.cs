namespace Spitfire.Web.Users.Create
{
    using Domain;

    public class CreateUserResponse
    {
        public CreateUserResponse(User user)
        {
            Id = user.Id;
            Name = user.Username;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}
