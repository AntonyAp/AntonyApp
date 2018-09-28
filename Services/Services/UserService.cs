using DomainModel;
using Services.DataAccessProviders;
using Services.Services.Contracts;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IDataAccessProvider dataAccessProvider;

        public UserService()
        {
            dataAccessProvider = new EntityFrameworkDataAccessProvider();
        }
        public UserContext db = new UserContext();

        public void Add(User user)
        {
            dataAccessProvider.Add(user);
        }

        public void Save(User user)
        {
            dataAccessProvider.Save(user);
        }

        public string CheckData(User user)
        {
            return dataAccessProvider.CheckData(user);
        }
    }
}