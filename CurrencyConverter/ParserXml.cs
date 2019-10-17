using System;
using CurrencyConverter;
using System.Xml;

public class ParserXml : IParser
{
    private XmlDocument xmlDocument { get; set; }

    public ParserXml(XmlDocument xmlDocument)
    {
        this.xmlDocument = xmlDocument;
    }
    public void Parse()
    {
        Console.WriteLine(xmlDocument.OuterXml);
    }
}