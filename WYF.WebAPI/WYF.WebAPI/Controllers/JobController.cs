using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WYF.WebAPI.Data;
using WYF.WebAPI.Models.BindingModels.Job;
using WYF.WebAPI.Models.EntityModels.Job;
using WYF.WebAPI.Models.EntityModels.User;

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


        [Route("Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddJobPosting(AddJobPostingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobPosting jobPosting = AutoMapper.Mapper.Map<AddJobPostingBindingModel, JobPosting>(model);
            Employer postingCreator = await this._context.Employers.FindAsync(model.PostingCreatorId);
            postingCreator.JobPostings.Add(jobPosting);
            jobPosting.PostingCreator = postingCreator;
            this._context.JobPostings.Add(jobPosting);
            this._context.SaveChanges();

            return Ok();
        }




    }
}
