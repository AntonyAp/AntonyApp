using System.Collections.Generic;
using DomainModel;

namespace Services.Services.Contracts
{
    public interface IDataAccessProvider
    {
        void Add(User user);
        bool ValidateCredentials(User user);
        List<User> ListOfUsers();
        User FindUser(int id);
        void Delete(int id);
        void Edit(User user);
    }
}