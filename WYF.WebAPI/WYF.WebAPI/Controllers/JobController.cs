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
using WYF.WebAPI.Models.Enums.Common;
using WYF.WebAPI.Models.Enums.Job;
using WYF.WebAPI.Models.Utilities;
using WYF.WebAPI.Models.ViewModels.Job;

namespace WYF.WebAPI.Controllers
{
    [RoutePrefix("api/Job")]
    public class JobController : ApiController
    {
        private WyfDbContext _context = WyfDbContext.Create();

        [Route("All")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<JobPostingViewModel>> AllJobPostings()
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

            JobPostingViewModel[] allJobPostingAsViewModels =
                AutoMapper.Mapper.Map<JobPostingViewModel[]>(_context.JobPostings.ToArray());

            return allJobPostingAsViewModels;
        }


        [Route("Add")]
        [HttpPost]
        [Authorize(Roles = "Employer")]
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

        
        [HttpGet]
        [Route("HierarchyLevels")]
        [AllowAnonymous]
        public IOrderedEnumerable<KeyValuePair<byte, string>> GetHierarchyLevels()
        {
            Dictionary<byte, string> allHierarchyLevels = EnumUtil.GetValuesAsNumbersWithNames<HierarchyLevel>();

            if (allHierarchyLevels == null || allHierarchyLevels.Count == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("There are no HierarchyLevels in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            var allHierarchyLevelsSorted = from entry in allHierarchyLevels orderby entry.Value ascending select entry;

            return allHierarchyLevelsSorted;
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        [AllowAnonymous]
        public async Task<JobPostingViewModel> GetJobPostingById(int id)
        {
            JobPosting jobPosting =  await this._context.JobPostings.FindAsync(id);

            if (jobPosting == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The requested Job Posting doesn't exist in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            JobPostingViewModel viewModel = AutoMapper.Mapper.Map<JobPostingViewModel>(jobPosting);

            return viewModel;
        }

        [HttpPost]
        [Route("Edit/{id:int}")]

        [Authorize(Roles = "Employer")]
        public async Task<JobPostingViewModel> EditJobPostingById(int id, JobPostingViewModel editedModel)
        {
            JobPosting jobPosting = await this._context.JobPostings.FindAsync(id);

            if (jobPosting == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The Job Posting which you want to edit doesn't exist in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            JobPostingViewModel viewModel = AutoMapper.Mapper.Map<JobPostingViewModel>(jobPosting);
            return viewModel;
        }


    }
}
