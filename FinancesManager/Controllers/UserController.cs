using System.Web.Mvc;
using System.Web.Security;

namespace FinancesManager.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.UserName, user.Password))
                {
                    Session["User"] = user;
                    return Redirect("~/Static/Index.html");
                }
                else
                {
                    ModelState.AddModelError("", "Username/password is incorrect.");
                }

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            throw new System.NotImplementedException();
        }
    }
}
