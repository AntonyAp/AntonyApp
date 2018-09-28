using DomainModel;

namespace Services.Services.Contracts
{
    public interface IDataAccessProvider
    {
        void Add(User user);

        void Save(User user);

        string CheckData(User user);
    }
}