using System;
using CurrencyConverter.Data;
using CurrencyConverter.Core;

namespace CurrencyConverter.UI
{
    public class Menu
    {
        // Making HTTP request and downloading XML file.
        public void Run()
        {
            string url = "http://www.nbp.pl/kursy/xml/LastA.xml";
            Console.WriteLine("Connectiong with: {0}", url);
            var connection = new Connection(url);
            
            // Parsing XML file.
            Console.WriteLine("Parsing XML file...");
            var parserXml = new ParserXml(connection.GetResource());
            var currencyList = parserXml.Parse();
            
            Console.WriteLine("List of available currency:");
            Console.WriteLine("Code\tName");

            for(int i = 0; i < currencyList.Length; i++)
            {
                Console.WriteLine(currencyList[i].Code + "\t" + currencyList[i].Name);
            }

            Console.WriteLine("\nTIP: Type in currency code.");
            Console.Write("From: ");
            string input_from = Console.ReadLine();
            Console.Write("To: ");
            string input_to = Console.ReadLine();
            
            while(true)
            {
                Console.Write("Ammount: ");
                try
                {
                    double input_ammount = Convert.ToDouble(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Incorrect input value, try again.");
                    continue;
                }
                break;
            }
        }

    }
}
