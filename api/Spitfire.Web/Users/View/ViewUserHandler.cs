namespace Spitfire.Web.Users.View
{
    using System.Linq;
    using Data;
    using GNaP.Data.Scope.EntityFramework.Interfaces;
    using MediatR;

    public class ViewUserHandler : IRequestHandler<ViewUserRequest, ViewUserResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public ViewUserHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public ViewUserResponse Handle(ViewUserRequest request)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var context = scope.Get<SpitfireDbContext>();
                var user = context.Users.SingleOrDefault(x => x.Id == request.Id);

                return new ViewUserResponse(user);
            }
        }
    }
}
