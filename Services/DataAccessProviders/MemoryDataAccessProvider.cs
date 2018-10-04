using System;
using DomainModel;
using Services.Services.Contracts;

namespace Services.DataAccessProviders
{
    // TODO: Store users in RAM while the app is running
    public class MemoryDataAccessProvider : IDataAccessProvider
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

       public bool ValidateCredentials(User user)
        {
            throw new NotImplementedException();
        }
    }
}
