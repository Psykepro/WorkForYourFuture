using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WYF.WebAPI.Data;
using WYF.WebAPI.Models.EntityModels.Common;
using WYF.WebAPI.Models.Enums.Common;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Controllers
{
    [RoutePrefix("api/Common")]
    public class CommonController : ApiController
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
                City newCity = new City() {Name = "Sofia"};
                _context.Cities.Add(newCity);
                _context.SaveChanges();
                allCities = new string[1] { newCity.Name };
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent("There are no Cities in the database."),
                //    ReasonPhrase = "Missing Resource Exception"
                //});
            }

            return allCities;
        }

        [Route("Languages")]
        [HttpGet]
        public IOrderedEnumerable<KeyValuePair<byte, string>> GetLanguages()
        {
            Dictionary<byte, string> allLanguages = EnumUtil.GetValuesAsNumbersWithNames<Language>();

            if (allLanguages == null || allLanguages.Count == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("There are no Languages in the database."),
                    ReasonPhrase = "Missing Resource Exception"
                });
            }

            var allLanguagesSorted = from entry in allLanguages orderby entry.Value ascending select entry;

            return allLanguagesSorted;
        }
    }
}
