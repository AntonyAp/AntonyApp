using System.Web.Mvc;
using testtest.Models;
using Service;

namespace testtest.Controllers
{
    public class RegistrationController : Controller
    {
        
        // GET: Registration
        public ActionResult RegistrationPage()
        {
            return View();
        }
        public ActionResult Registration( User user)
        {
            var userService = new UserService();
            userService.Add(user);
            userService.Save(user);
            return RedirectToAction("LoginPage", "Autorization");
        }
    }
}