namespace Spitfire.Web.Users.List
{
    using System.Linq;
    using Data;
    using GNaP.Data.Scope.EntityFramework.Interfaces;
    using MediatR;

    public class ListUsersHandler : IRequestHandler<ListUsersRequest, ListUsersResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public ListUsersHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public ListUsersResponse Handle(ListUsersRequest request)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var context = scope.Get<SpitfireDbContext>();

                var users = context.Users.ToList().Select(user => new ListUsersResponseItem(user));

                return new ListUsersResponse(users);
            }
        }
    }
}
