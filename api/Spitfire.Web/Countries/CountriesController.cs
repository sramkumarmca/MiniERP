using GNaP.WebApi.Versioning;
using MediatR;
using Spitfire.Web.Countries.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spitfire.Web.Countries
{
    [RoutePrefix("countries")]
    public class CountriesController : ApiController
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException("mediator");

            _mediator = mediator;
        }

        [VersionedRoute]
        //[AuthorizeRoles(Roles.Manager, Roles.Administrator)]
        public IHttpActionResult Post([FromBody] CreateCountryRequest request)
        {
            return Ok(_mediator.Send(request));
        }

    }
}
