using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Data
{
    public class CurrencyList
    {
        private List<Currency> ListObj;

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

        public Currency this[int i]
        {
            get { return ListObj[i]; }
        }
    }
}