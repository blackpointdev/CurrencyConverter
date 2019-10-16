using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection("http://www.nbp.pl/kursy/xml/LastA.xml");
            Console.WriteLine(connection.GetData().InnerXml);
        }
    }
}
