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
             //dataAccessProvider = new EntityFrameworkDataAccessProvider();
           // dataAccessProvider = new AdoNetDataAccessProvider();
            dataAccessProvider = new XmlDataAccessProvider();
        }

        public void Add(User user)
        {
            dataAccessProvider.Add(user);
        }
        
        public bool ValidateCredentials(User user)
        {
            return dataAccessProvider.ValidateCredentials(user);
        }
    }
}