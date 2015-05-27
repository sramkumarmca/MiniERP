namespace Spitfire.Web.Users.Create
{
    using Domain;

    public class CreateUserResponse
    {
        public CreateUserResponse(User user)
        {
            Id = user.Id;
            DisplayName = user.Username;
        }

        public string DisplayName { get; set; }

        public int Id { get; set; }
    }
}
