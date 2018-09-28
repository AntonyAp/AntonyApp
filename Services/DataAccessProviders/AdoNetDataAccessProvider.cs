using System;
using DomainModel;
using Services.Services.Contracts;

namespace Services.DataAccessProviders
{
    // TODO: Store users in the database. Connect the database using ADO.NET
    public class AdoNetDataAccessProvider : IDataAccessProvider
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public string CheckData(User user)
        {
            throw new NotImplementedException();
        }
    }
}
