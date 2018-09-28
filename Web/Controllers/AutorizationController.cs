using System.Web.Mvc;
using DomainModel;
using Services;
using Services.Services.Contracts;

namespace Web.Controllers
{
    public class AutorizationController : Controller
    {
        private readonly IUserService userService;

        public AutorizationController()
        {
            userService = new UserService();
        }

        // GET: Autorization
        public ActionResult Login(User model)
        {
            var chekedDirection = userService.CheckData(model);
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