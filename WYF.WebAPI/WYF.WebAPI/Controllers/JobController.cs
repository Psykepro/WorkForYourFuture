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

        
    }
}
