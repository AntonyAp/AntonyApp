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
            XmlDocument xDoc = new  XmlDocument();
            xDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
             XmlElement xRoot = xDoc.DocumentElement;
                   XmlElement userElem = xDoc.CreateElement("user");
                        XmlAttribute nameAttr = xDoc.CreateAttribute("name");
                        XmlElement loginElem = xDoc.CreateElement("login");
                        XmlElement passwordElem = xDoc.CreateElement("password");
                            XmlText nameText = xDoc.CreateTextNode(user.Name);
                            XmlText loginText = xDoc.CreateTextNode(user.Login);
                            XmlText passwordText = xDoc.CreateTextNode(user.Password);

            nameAttr.AppendChild(nameText);
            loginElem.AppendChild(loginText);
            passwordElem.AppendChild(passwordText);
                userElem.Attributes.Append(nameAttr);
                userElem.AppendChild(loginElem);
                userElem.AppendChild(passwordElem);
             xRoot.AppendChild(userElem);
            xDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
        }

        public string CheckData(User user)
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
            IEnumerable<XElement> users =
                from el in root.Elements("user")
                where (string) el.Element("login") == user.Login && (string) el.Element("password") == user.Password
                select el;
            var redirectViewName = users.Any()? "Football" : "LoginPage";
            return redirectViewName;
        }
    }
}
