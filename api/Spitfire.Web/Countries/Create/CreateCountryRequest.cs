using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Spitfire.Web.Countries.Create
{
    public class CreateCountryRequest : IRequest<CreateCountryResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}
