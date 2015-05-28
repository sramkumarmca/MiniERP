namespace Spitfire.Web.Users.List
{
    using System;
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
            Version = Convert.ToBase64String(user.Timestamp);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Version { get; set; }
    }
}
