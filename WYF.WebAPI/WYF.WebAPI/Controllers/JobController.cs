using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WYF.WebAPI.Data;
using WYF.WebAPI.Models.EntityModels.Job;

namespace WYF.WebAPI.Controllers
{
    [RoutePrefix("api/Job")]
    public class JobController : ApiController
    {
        private WyfDbContext _context = WyfDbContext.Create();

        [Route("All")]
        [HttpGet]
        public IEnumerable<JobPosting> AllJobPostings()
        {
            JobPosting[] allJobPostings = _context.JobPostings.ToArray();

            if (allJobPostings == null || allJobPostings.Length == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("There are no JobPostings in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            return allJobPostings;

        }

        
    }
}
