namespace Spitfire.Domain
{
    public class User
    {
        private User()
        {
        }

        public User(string username, int age)
        {
            Username = username;
            Age = age;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public byte[] Timestamp { get; set; }
    }
}