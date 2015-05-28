namespace Spitfire.Web.Users.List
{
    using System.Collections.Generic;
    using Domain;

    public class ListUsersResponse : List<ListUsersResponseItem>
    {
        public ListUsersResponse(IEnumerable<ListUsersResponseItem> items)
            : base(items)
        {
        }
    }

    public class ListUsersResponseItem
    {
        public ListUsersResponseItem(User user)
        {
            Id = user.Id;
            Name = user.Username;
            Age = user.Age;
        }

        public int Age { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
