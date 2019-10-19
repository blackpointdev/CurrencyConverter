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

            currencyList.AddCurrency(new Currency("zloty polski", 1, "PLN", 1));
            
            Console.WriteLine("List of available currency:");
            Console.WriteLine("Code\tName");

            for(int i = 0; i < currencyList.Length; i++)
            {
                Console.WriteLine(currencyList[i].Code + "\t" + currencyList[i].Name);
            }

            Currency from_currency = null;
            Currency to_currency = null;
            double input_ammount = 0;

            Console.WriteLine("\nTIP: Type in currency code.");
            
            while(true)
            {
                Console.Write("From: ");
                string input_from = Console.ReadLine();

                try
                {
                    from_currency = currencyList.FindCurrencyByCode(input_from);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Can't find currency with given code. Try again.");
                    continue;
                }
                break;
            }

            while(true)
            {
                Console.Write("To: ");
                string input_to = Console.ReadLine();

                try
                {
                    to_currency = currencyList.FindCurrencyByCode(input_to);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Can't find currency with given code. Try again.");
                    continue;
                }
                break;
            }
            
            while(true)
            {
                Console.Write("Ammount: ");
                try
                {
                    input_ammount = Convert.ToDouble(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Incorrect input value, try again.");
                    continue;
                }
                break;
            }

            Console.WriteLine("Result: " + Converter.Convert(from_currency, to_currency, input_ammount));
        }

    }
}
