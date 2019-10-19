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

            Console.WriteLine("\nTIP: Type in currency code.");
            
            Console.Write("From: ");
            Currency from_currency = GetInputCurrency(currencyList);
            Console.Write("To: ");
            Currency to_currency = GetInputCurrency(currencyList);
            Console.Write("Ammount: ");
            double input_ammount = GetInputAmmount();
            
            DisplayResults(from_currency, to_currency, input_ammount);
        }

        private Currency GetInputCurrency(CurrencyList currencyList)
        {
            while(true)
            {
                string input = Console.ReadLine();

                try
                {
                    return currencyList.FindCurrencyByCode(input);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Can't find currency with given code. Try again.");
                    continue;
                }
            }
        }

        private double GetInputAmmount()
        {
            while(true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Incorrect input value, try again.");
                    continue;
                }
            }
        }

        private void DisplayResults(Currency from, Currency to, double ammount)
        {
            Console.WriteLine("{0} exchange rate: 1 PLN = {1} {0}\n"
                            + "{2} exchange rate: 1 PLN = {3} {2}", 
                            from.Code, from.ExchangeRate, to.Code, to.ExchangeRate);
            Console.WriteLine("Result: {0} {1} = {2} {3}", 
                            ammount, from.Code, Math.Round(Converter.Convert(from, to, ammount), 2), to.Code);
        }

    }
}
