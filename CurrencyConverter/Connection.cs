using System;
using System.Xml;
using System.Net;

namespace CurrencyConverter
{
    class Connection
    {
        public string Url { get; private set; }

        public Connection(string Url)
        {
            this.Url = Url;
        }

        public XmlDocument GetResource()
        {
            string xmlStr;
            using(var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(Url);
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            return xmlDoc;
        }
    }
}