using DomainModel;

namespace Services.Services.Contracts
{
    public interface IUserService
    {
        void Add(User user);

        void Save(User user);

        string CheckData(User user);
    }
}