using System.Web;
using System.Xml;
using System.Xml.Linq;
using DomainModel;
using Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Services.DataAccessProviders
{
    // TODO: Store users in the xml file
    public class XmlDataAccessProvider : IDataAccessProvider
    {
        public void Add(User user)
        {
            var xDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
            var root = xDoc.Element("users");
            root.Add(new XElement("user",
                new XAttribute("name", user.Name),
                new XElement("login", user.Login),
                new XElement("password", user.Password)));
            xDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new System.NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> ListOfUsers()
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCredentials(User user)
        {
            var correctData = false;
            var xDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
            var root = xDoc.Element("users");
            IEnumerable<XElement> users =
                from el in root.Elements("user")
                where (string) el.Element("login") == user.Login && (string) el.Element("password") == user.Password
                select el;
            if (users.Any()) correctData = true;
            return correctData;
        }
    }
}
