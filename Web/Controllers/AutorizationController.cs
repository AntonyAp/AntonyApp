
using System.Linq;
using System.Web.Mvc;
using testtest.Models;

namespace testtest.Controllers
{
       public class AutorizationController : Controller
    {
        UserContext db = new UserContext();
        // GET: Autorization
        public ActionResult Login(User model)
        {
            var users = db.Users;
            var userExists = users.Any(x => x.Login == model.Login && x.Password == model.Password);
            var redirectViewName = userExists ? "Football" : "LoginPage";
                return RedirectToAction(redirectViewName, "Autorization");
            }

            public ActionResult LoginPage()
        {
            return View();
        }

            public ActionResult Football()
        {
       
            return View();
        }
    }
}