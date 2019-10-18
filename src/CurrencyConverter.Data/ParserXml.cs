using System;
using CurrencyConverter.Data;
using System.Xml;

public class ParserXml : IParser
{
    private XmlDocument xmlDoc;

    public ParserXml(XmlDocument xmlDoc)
    {
        this.xmlDoc = xmlDoc;
    }
    public CurrencyList Parse()
    {
        CurrencyList currencyList = new CurrencyList();

        XmlNodeList nodes = xmlDoc.SelectNodes("tabela_kursow/pozycja"); // Possibly better to use LINQ to read XML here

        foreach(XmlNode node in nodes)
        {
            string name = node.SelectSingleNode("nazwa_waluty").InnerText;
            int factor = Int32.Parse(node.SelectSingleNode("przelicznik").InnerText);
            string code = node.SelectSingleNode("kod_waluty").InnerText;
            decimal exchange_rate = Convert.ToDecimal(node.SelectSingleNode("kurs_sredni").InnerText);

            Currency currency = new Currency(name, factor, code, exchange_rate);
            currencyList.AddCurrency(currency);
        }

        return currencyList;
    }
}