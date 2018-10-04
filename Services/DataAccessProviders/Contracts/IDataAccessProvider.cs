using DomainModel;

namespace Services.Services.Contracts
{
    public interface IDataAccessProvider
    {
        void Add(User user);
        bool ValidateCredentials(User user);
    }
}