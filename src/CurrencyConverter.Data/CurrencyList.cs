using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Data
{
    public class CurrencyList
    {
        private List<Currency> ListObj;
        public int Length { private set; get; }

        public CurrencyList(params Currency[] list)
        {
            ListObj = new List<Currency>();
            Length = 0;

            foreach(Currency curr in list)
            {
                ListObj.Add(curr);
            }

            Length = ListObj.Count;
        }

        public CurrencyList() 
        {
            ListObj = new List<Currency>();
            Length = 0;
        }

        public void AddCurrency(Currency currency) 
        {
            ListObj.Add(currency);
            Length += 1;
        }
        public void RemoveCurrency(string code)
        {
            var item = ListObj.SingleOrDefault(x => x.Code == code);
            if (item != null)
            {
                ListObj.Remove(item);
                Length -= 1;
            }
        }

        public Currency this[int i]
        {
            get { return ListObj[i]; }
        }
    }
}