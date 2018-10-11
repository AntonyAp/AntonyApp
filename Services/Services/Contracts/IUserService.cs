using System.Collections.Generic;
using DomainModel;

namespace Services.Services.Contracts
{
    public interface IUserService
    {
        void Add(User user);

       bool ValidateCredentials(User user);
        User FindUser(int id);
        List<User> ListOfUsers();
        void Delete(int id);
        void Edit(User user);
    }
}