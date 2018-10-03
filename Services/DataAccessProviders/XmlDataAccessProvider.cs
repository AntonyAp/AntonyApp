using System.Xml.Linq;
using DomainModel;
using Services.Services.Contracts;
namespace Services.DataAccessProviders
{
    // TODO: Store users in the xml file
    public class XmlDataAccessProvider : IDataAccessProvider
    {
        public void Add(User user)
        {
            XDocument doc = new XDocument();
            XElement users = new XElement("users");
            doc.Add(users);
        }
        
        public string CheckData(User user)
        {
            return "";
        }
    }
}
