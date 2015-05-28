namespace Spitfire.Web.Users.View
{
    using Domain;

    public class ViewUserResponse
    {
        public ViewUserResponse(User user)
        {
            Id = user.Id;
            Name = user.Username;
            Age = user.Age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
