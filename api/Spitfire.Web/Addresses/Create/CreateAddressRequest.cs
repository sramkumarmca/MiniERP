using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Web.Addresses.Create
{
    public class CreateAddressRequest : IRequest<CreateAddressResponse>
    {
        public string StreetNumber { get; set; }
        public string Route { get; set; }
        public string Locality { get; set; }
        public string AdministrativeArea { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; } 
    }
}