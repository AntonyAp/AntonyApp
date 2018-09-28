
using Service;
using System.Linq;
using System.Web.Mvc;
using testtest.Models;

namespace testtest.Controllers
{
       public class AutorizationController : Controller
    {
        
        // GET: Autorization
        public ActionResult Login(User model)
        {
            UserService userService = new UserService();
            var chekedDirection =userService.CheckData(model);
                return RedirectToAction(chekedDirection, "Autorization");
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