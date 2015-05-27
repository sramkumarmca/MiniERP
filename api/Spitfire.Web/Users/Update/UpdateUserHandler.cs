namespace Spitfire.Web.Users.Update
{
    using System.Linq;
    using Data;
    using GNaP.Data.Scope.EntityFramework.Interfaces;
    using MediatR;

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public UpdateUserHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public UpdateUserResponse Handle(UpdateUserRequest request)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var context = scope.Get<SpitfireDbContext>();

                var user = context.Users.FirstOrDefault(x => x.Id == request.Id);

                user.Username = request.Name;

                scope.SaveChanges();

                return new UpdateUserResponse();
            }
        }
    }
}