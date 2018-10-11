using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using DomainModel;
using Services;
using Services.Services.Contracts;

namespace Web.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD 
        private readonly IUserService userService;

        public CRUDController()
        {
            userService = new UserService();
        }

        public ActionResult Index()
        {
                return View(userService.ListOfUsers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
                userService.Add(user);
                return RedirectToAction("Index");
            
        }
        public ActionResult Details(int id)
        {
           
                return View(userService.FindUser(id));
            
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            userService.Edit(user);
            return RedirectToAction("Index");

         }
        public ActionResult Delete(int id)
        {
            return View();
        }
    
    [HttpPost]
        public ActionResult Delete(int id,User user)
        {
                userService.Delete(id);
                return RedirectToAction("Index");
            
        }
    }
}