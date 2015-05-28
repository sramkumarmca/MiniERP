namespace Spitfire.Web.Users.Create
{
    using Data;
    using Domain;
    using GNaP.Data.Scope.EntityFramework.Interfaces;
    using MediatR;

    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public CreateUserHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public CreateUserResponse Handle(CreateUserRequest request)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var context = scope.Get<SpitfireDbContext>();

                var user = context.Users.Add(new User(request.Name, request.Age));

                scope.SaveChanges();

                return new CreateUserResponse(user);
            }
        }
    }
}
