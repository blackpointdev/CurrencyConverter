using System;
using CurrencyConverter.Data;

namespace CurrencyConverter.Converter
{
    public class Converter
    {
        public static decimal Convert(Currency c1, Currency c2, decimal ammount)
        {
            decimal tmp = c1.ExchangeRate * ammount;
            return tmp/c2.ExchangeRate;
        }
    }
}