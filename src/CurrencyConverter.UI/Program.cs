using System;
using CurrencyConverter.Data;
using CurrencyConverter.Core;

namespace CurrencyConverter.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connectiong with: http://www.nbp.pl/kursy/xml/LastA.xml");

            // Making HTTP request and downloading XML file.
            var connection = new Connection("http://www.nbp.pl/kursy/xml/LastA.xml");
            // Parsing XML file.
            var parserXml = new ParserXml(connection.GetResource());
            var currencyList = parserXml.Parse();

            Console.WriteLine(Converter.Convert(currencyList[0], currencyList[1], 20));
        }
    }
}
