using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connectiong with: http://www.nbp.pl/kursy/xml/LastA.xml");

            // Making HTTP request and downloading XML file.
            Connection connection = new Connection("http://www.nbp.pl/kursy/xml/LastA.xml");
            // Parsing XML file.
            ParserXml parserXml = new ParserXml(connection.GetResource());
            parserXml.Parse();
        }
    }
}
