using Spitfire.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Spitfire.Web.Countries.Create
{
    public class CreateCountryResponse
    {
        public CreateCountryResponse(Country country)
        {
            Id = country.Id;
            Name = country.Name;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}
