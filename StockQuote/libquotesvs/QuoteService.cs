using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bloomberg
{
    public class QuoteService
    {
        IList<string> fqQuotes;
        IList<string> tmpQuotes;

        public QuoteService()
        {
            fqQuotes = new List<string>(){ "BAC", "C", "CS", "GS", "JPM", "MS" };
        }

        protected Task<IList<string>> ParseQuoteListAsync(string csvsymbols = "-djia", bool preserve = true)
        {
            return Task.Run(() =>
                {
                    var trimmedcapitalizedquotes = csvsymbols.StartsWith("-djia") ?   SymbolLibrary.DJIA30.Select(q => q.Trim()): 
                                                   csvsymbols.StartsWith("-nasdaq") ? SymbolLibrary.NASDAQ.ToList() : 
                                                                                      csvsymbols.Split(new char[] { ',' }).Select(q => q.Trim().ToUpper());
                    if (preserve)
                    {
                        fqQuotes = trimmedcapitalizedquotes.ToList();
                        if(null != tmpQuotes)
                            tmpQuotes.Clear();
                        return fqQuotes;
                    }
                    else
                    {
                        tmpQuotes = trimmedcapitalizedquotes.ToList();
                        return tmpQuotes;
                    }
                });
        }

        public virtual Task<List<StockQuote>> GetStockQuoteAsync(string csvsymbols = "-djia", bool preserve = true, int timeoutInMinutes = 3)
        {
            return Task.Run(async () =>
            {
                var quotes = new List<StockQuote>();
                try
                {
                    var symbols = await ParseQuoteListAsync(csvsymbols, preserve);

                    foreach (var s in symbols)
                    {
                        var result = GetStockQuote(s, timeoutInMinutes);
                        if(null != result)
                            quotes.Add(result);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    throw;
                } 

                return quotes;
            });
        }

        public StockQuote GetStockQuote(string symbol, int timeoutInMinutes = 3)
        {
            StockQuote quote = null;
            var sw = new Stopwatch();     

            var quotesvs = new StockQuoteServiceClient();
            quotesvs.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(timeoutInMinutes);

            sw.Start();  
            quote = quotesvs.GetStockQuote(symbol);
            sw.Stop();

            if(null != quote)
                quote.ElapsedMilliseconds = sw.ElapsedMilliseconds.ToString();            

            return quote;
        }
    }
}

