using System.Linq;
using DomainModel;
using System.Collections.Generic;
using System.Data.Entity;
using Services.Services.Contracts;

namespace Services.DataAccessProviders
{
    public class EntityFrameworkDataAccessProvider : IDataAccessProvider
    {
        public UserContext db = new UserContext();

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User removedUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            db.Users.Remove(removedUser);
            db.SaveChanges();
        }

        public void Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public User FindUser(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> ListOfUsers()
        {
            
            return db.Users.ToList();
        }

        public bool ValidateCredentials(User user)
        {
            var correctData = false;
            var users = db.Users;
            var userExists = users.Any(x => x.Login == user.Login && x.Password == user.Password);
            if(userExists) correctData=true;
            return correctData;
        }
    }
}
