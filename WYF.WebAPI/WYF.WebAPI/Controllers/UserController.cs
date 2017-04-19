using System.Web.Mvc;

namespace WYF.WebAPI.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}