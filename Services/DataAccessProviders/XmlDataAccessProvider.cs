using System.Web;
using System.IO;
using System.Net;
using System.Xml;
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
            var direction = "LoginPage";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/XMLStorage.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "login")
                    {
                        if (childnode.InnerText != user.Login) break;
                    }

                    if (childnode.Name == "password")
                    {
                        if (childnode.InnerText != user.Password) break;
                        direction = "Football";
                        return direction;
                    }
                }
            }
            return direction;
        }
    }
}
