namespace Spitfire.Domain
{
    public class User
    {
        private User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }
    }
}