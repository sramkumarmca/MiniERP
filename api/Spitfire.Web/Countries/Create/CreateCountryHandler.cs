using GNaP.Data.Scope.EntityFramework.Interfaces;
using MediatR;
using Spitfire.Data;
using Spitfire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Web.Countries.Create
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryRequest, CreateCountryResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public CreateCountryHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public CreateCountryResponse Handle(CreateCountryRequest request)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var context = scope.Get<SpitfireDbContext>();

                var country = context.Countries.Add(new Country(request.Name));

                scope.SaveChanges();

                return new CreateCountryResponse(country);
            }
        }
    }
}