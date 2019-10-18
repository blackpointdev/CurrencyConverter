using System;
using CurrencyConverter.Data;

namespace CurrencyConverter.Core
{
    public class Converter
    {
        public static double Convert(Currency c1, Currency c2, double ammount)
        {
            double tmp = decimal.ToDouble(c1.ExchangeRate) * ammount;
            return tmp/decimal.ToDouble(c2.ExchangeRate);
        }
    }
}