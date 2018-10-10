using System.Linq;
using DomainModel;
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

        public User FindUser(int id)
        {
            User user = db.Users.Find(id);
            return user;
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
