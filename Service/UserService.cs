using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testtest.Models;

namespace Service
{
    public class UserService
    {
        public UserContext db = new UserContext();
         public void Add(User user)
        {
            db.Users.Add(user);
        }
        public void Save(User user)
        {
            db.SaveChanges();
        }
        public string CheckData(User user)
        {
            var users = db.Users;
            var userExists = users.Any(x => x.Login == user.Login && x.Password == user.Password);
            var redirectViewName = userExists ? "Football" : "LoginPage";
            return redirectViewName;
        }
    }
}