using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            foreach (var b in users)
            {
                if (model.Password == b.Password && model.Login == b.Login)
                    return RedirectToAction("Football", "Autorization");

            }

            {
                return RedirectToAction("LoginPage", "Autorization");
            }
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