using System.Web.Mvc;
using DomainModel;
using Services;
using Services.Services.Contracts;

namespace Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService userService;

        public RegistrationController()
        {
            userService = new UserService();
        }

        // GET: Registration
        public ActionResult RegistrationPage()
        {
            return View();
        }

        public ActionResult Registration( User user)
        {
            userService.Add(user);
            return RedirectToAction("LoginPage", "Autorization");
        }
    }
}