using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using DomainModel;
using Services.Services.Contracts;

namespace Services.DataAccessProviders
{
    // TODO: Store users in RAM while the app is running
    public class MemoryDataAccessProvider :Page, IDataAccessProvider 
    {
        public void Add(User user)
        {
            List<User> userList;
           if (HttpContext.Current.Application["UserList"] != null)
                {
                    userList = (List<User>) HttpContext.Current.Application["UserList"];
                }
                else
                {
                    userList = new List<User>();

                }

                userList.Add(user);
                HttpContext.Current.Application["UserList"] = userList;
            

        }
        public void Edit(User user)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ListOfUsers()
        {
            throw new NotImplementedException();
        }

        public bool ValidateCredentials(User user)
        {
            var correctData = false;
            if (HttpContext.Current.Application["UserList"] != null)
            {
                var userList = ((List<User>)HttpContext.Current.Application["UserList"]);
                if (userList.Any(x => x.Login == user.Login && x.Password == user.Password))
                {
                    correctData = true;
                }
            }
            return correctData;
        }
    }
}
