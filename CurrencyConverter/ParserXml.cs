using System;
using CurrencyConverter;
using System.Xml;

public class ParserXml : IParser
{
    private XmlDocument xmlDoc { get; set; }

    public ParserXml(XmlDocument xmlDoc)
    {
        this.xmlDoc = xmlDoc;
    }
    public void Parse()
    {
        // Console.WriteLine(xmlDocument.OuterXml);
        Console.WriteLine("Parsing...");
        
        // XmlNode node = xmlDoc.SelectSingleNode("tabela_kursow/pozycja/nazwa_waluty");
        
        // foreach(XmlNode node in xmlDoc.DocumentElement.ChildNodes)
        // {
        //     XmlNode innerNode = node.SelectSingleNode("nazwa_waluty");
        //     Console.WriteLine(innerNode.InnerText);
        // }

        XmlNodeList nodes = xmlDoc.SelectNodes("tabela_kursow/pozycja");

        foreach(XmlNode node in nodes)
        {
            string txt = node.SelectSingleNode("nazwa_waluty").InnerText;
            Console.WriteLine(txt);
            // TODO create Currency object!
        }
    }
}