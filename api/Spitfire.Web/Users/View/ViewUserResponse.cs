namespace Spitfire.Web.Users.View
{
    using Domain;

    public class ViewUserResponse
    {
        public ViewUserResponse(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Age = user.Age;
        }

        public int Age { get; set; }

        public int Id { get; set; }
        public string Username { get; set; }
    }
}
