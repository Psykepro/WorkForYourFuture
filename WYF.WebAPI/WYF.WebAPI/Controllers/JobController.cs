using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
    [System.Web.Http.RoutePrefix("api/Job")]
    public class JobController : ApiController
    {
        private WyfDbContext _context = WyfDbContext.Create();

        [System.Web.Http.Route("All")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.AllowAnonymous]
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


        [System.Web.Http.Route("Add")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize(Roles = "Employer")]
        [ValidateAntiForgeryToken()]
        public async Task<IHttpActionResult> AddJobPosting(AddJobPostingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobPosting jobPosting = AutoMapper.Mapper.Map<AddJobPostingBindingModel, JobPosting>(model);
            Employer postingCreator = await this._context.Employers.FindAsync(model.PostingCreatorId);

            if (postingCreator == null)
            {
                return BadRequest("You are not authorized for this action. Only Employers can add postings.");
            }

            postingCreator.JobPostings.Add(jobPosting);
            jobPosting.PostingCreator = postingCreator;
            try
            {
                this._context.JobPostings.Add(jobPosting);
                this._context.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("HierarchyLevels")]
        [System.Web.Http.AllowAnonymous]
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Details/{id:int}")]
        [System.Web.Http.AllowAnonymous]
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit/{id:int}")]
        [System.Web.Http.Authorize(Roles = "Employer")]
        [ValidateAntiForgeryToken()]
        public async Task<IHttpActionResult> GetEditJobPostingById(int id)
        {
            JobPosting jobPosting = await this._context.JobPostings.FindAsync(id);
            

            if (jobPosting == null)
            {
                return BadRequest("This posting doesn't exist in the database.");
            }

            var postingCreator = jobPosting.PostingCreator;
            if (postingCreator.UserId != RequestContext.Principal.Identity.GetUserId())
            {
                return BadRequest("You are not authorized to edit this Job Posting.");
            }

            JobPostingEditViewModel viewModel = AutoMapper.Mapper.Map<JobPostingEditViewModel>(jobPosting);

            return Ok(viewModel);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Edit")]
        [System.Web.Http.Authorize(Roles = "Employer")]
        [ValidateAntiForgeryToken()]
        public async Task<IHttpActionResult> EditJobPosting(JobPostingEditViewModel editedModel)
        {
            JobPosting jobPosting = await this._context.JobPostings.FindAsync(editedModel.Id);

            if (jobPosting == null)
            {
                return BadRequest("This posting doesn't exist in the database.");
            }

            var postingCreator = jobPosting.PostingCreator;
            if (postingCreator.UserId != RequestContext.Principal.Identity.GetUserId())
            {
                return BadRequest("You are not authorized to edit this Job Posting.");
            }

            try
            {
                jobPosting = AutoMapper.Mapper.Map<JobPosting>(editedModel);
                this._context.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }


            return Ok();
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("JobPostingApply/{jobPostingId:int}")]
        [System.Web.Http.Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken()]
        public async Task<IHttpActionResult> ApplyForJobPosting(int jobPostingId)
        {
            JobPosting jobPosting = await this._context.JobPostings.FindAsync(jobPostingId);
            if (jobPosting == null)
            {
                return BadRequest("The posting you want to apply doesn't exist in the database.");
            }

            Employee jobApplicant = await this._context.Employees.FirstOrDefaultAsync(e => e.UserId == RequestContext.Principal.Identity.GetUserId());
            if (jobApplicant == null)
            {
                return BadRequest("You are not authorized to this action. Only employees can apply for job.");
            }
            
            try
            {
                JobApplication newJobPostingApplication = new JobApplication()
                {
                    JobPosting = jobPosting,
                    JobApplicant = jobApplicant,
                    JobPostingCreatorId = jobPosting.PostingCreatorId,
                    JobPostingCreator = jobPosting.PostingCreator
                };
                this._context.JobApplications.Add(newJobPostingApplication);
                this._context.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }


    }
}
