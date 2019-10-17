namespace CurrencyConverter.Data
{
    public class Currency
    {
        public string Name { get; set; }
        public int Factor { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; }

        public Currency(string name, int factor, string code, decimal exchangeRate)
        {
            Name = name;
            Factor = factor;
            Code = code;
            ExchangeRate = exchangeRate;
        }

        public Currency()
        {
            Name = "";
            Factor = 0;
            Code = "";
            ExchangeRate = 0;
        }
    }
}