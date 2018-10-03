using DomainModel;

namespace Services.Services.Contracts
{
    public interface IDataAccessProvider
    {
        void Add(User user);
        string CheckData(User user);
    }
}