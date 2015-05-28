namespace Spitfire.Web.Users.Verify
{
    using System.Linq;
    using Data;
    using GNaP.Data.Scope.EntityFramework.Interfaces;
    using MediatR;

    public class VerifyUserHandler : IRequestHandler<VerifyUserRequest, VerifyUserResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public VerifyUserHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public VerifyUserResponse Handle(VerifyUserRequest request)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var context = scope.Get<SpitfireDbContext>();

                var user = context.Users.SingleOrDefault(x => x.Username == request.Name);

                return user != null
                    ? new VerifyUserResponse()
                    : null;
            }
        }
    }
}
