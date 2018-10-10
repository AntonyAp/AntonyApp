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
            using (UserContext db = new UserContext())

            {
                return View(db.Users.ToList());
            }

            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            using (UserContext db = new UserContext())

            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (UserContext db = new UserContext())

            {
                return View(db.Users.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (UserContext db = new UserContext())

            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Delete(int id)
        {
            using (UserContext db = new UserContext())

            {
                return View(db.Users.Where(x => x.Id == id).FirstOrDefault());
            }
        }
    
    [HttpPost]
        public ActionResult Delete(int id,User user)
        {
            using (UserContext db = new UserContext())

            {
                User removedUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
                db.Users.Remove(removedUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}