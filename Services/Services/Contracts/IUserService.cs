using DomainModel;

namespace Services.Services.Contracts
{
    public interface IUserService
    {
        void Add(User user);

       bool ValidateCredentials(User user);
    }
}