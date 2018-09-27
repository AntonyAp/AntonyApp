using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testtest.Models;
using System.Data.Entity;
using static Service.UserService;
using Service;

namespace testtest.Controllers
{
    public class RegistrationController : Controller
    {
        private UserContext db = new UserContext();
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