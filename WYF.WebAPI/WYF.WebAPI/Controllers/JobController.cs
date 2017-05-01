using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WYF.WebAPI.Data;

namespace WYF.WebAPI.Controllers
{
    [RoutePrefix("api/Job")]
    public class JobController : ApiController
    {
        private WyfDbContext _context = WyfDbContext.Create();

        //[Authorize]
        [Route("Cities")]
        [HttpGet]
        public IEnumerable<string> Cities()
        {
            string[] allCities = _context.Cities.Select(c => c.Name).ToArray();
            
            if (allCities == null || allCities.Length == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("There are no Cities in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            return allCities;
        }
    }
}
