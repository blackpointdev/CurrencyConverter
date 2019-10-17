using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Data
{
    public class CurrencyList
    {
        public List<Currency> ListObj { private set; get; }

        public CurrencyList(params Currency[] list)
        {
            ListObj = new List<Currency>();

            foreach(Currency curr in list)
            {
                ListObj.Add(curr);
            }
        }

        public CurrencyList() => ListObj = new List<Currency>();

        public void AddCurrency(Currency currency) => ListObj.Add(currency);
        public void RemoveCurrency(string code)
        {
            var item = ListObj.SingleOrDefault(x => x.Code == code);
            if (item != null)
            {
                ListObj.Remove(item);
            }
        }
    }
}