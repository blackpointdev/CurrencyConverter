using System;

namespace CurrencyConverter.Data
{
    interface IParser
    {
        CurrencyList Parse();
    }
}