using Spitfire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Web.Addresses.Create
{
    public class CreateAddressResponse
    {
        public CreateAddressResponse(Address address)
        {
            FullAddress = string.Format(address.Route, address.StreetNumber, address.Locality, address.Country, address.Address_ID, "{4}: {0} {1}, {2}, {3}"); 
        }

        public string FullAddress { get; set; }
    }
}