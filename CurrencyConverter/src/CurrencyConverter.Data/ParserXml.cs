using System;
using CurrencyConverter;
using System.Xml;

public class ParserXml : IParser
{
    private XmlDocument xmlDoc;

    public ParserXml(XmlDocument xmlDoc)
    {
        this.xmlDoc = xmlDoc;
    }
    public void Parse()
    {
        Console.WriteLine("Parsing...");

        XmlNodeList nodes = xmlDoc.SelectNodes("tabela_kursow/pozycja"); // Possibly better to use LINQ to read XML here

        foreach(XmlNode node in nodes)
        {
            string txt = node.SelectSingleNode("nazwa_waluty").InnerText;
            Console.WriteLine(txt);
            // TODO create Currency object!
        }
    }
}