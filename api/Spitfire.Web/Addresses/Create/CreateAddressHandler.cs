using GNaP.Data.Scope.EntityFramework.Interfaces;
using MediatR;
using Spitfire.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spitfire.Domain;

namespace Spitfire.Web.Addresses.Create
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressRequest, CreateAddressResponse>
    {
        private readonly IDbScopeFactory _dbScopeFactory;

        public CreateAddressHandler(IDbScopeFactory dbScopeFactory)
        {
            _dbScopeFactory = dbScopeFactory;
        }

        public CreateAddressResponse Handle(CreateAddressRequest request)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var context = scope.Get<SpitfireDbContext>();

                var address = context.Addresses.Add(new Address(request.Route, request.StreetNumber,request.PostalCode,request.Locality,request.AdministrativeArea, request.Country));

                scope.SaveChanges();

                return new CreateAddressResponse(address);
            }
        }
    
    }
}