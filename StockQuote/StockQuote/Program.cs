using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Runtime;
using Bloomberg;

namespace StockQuoteApp
{
    
    class Program
    {
		public static void GetStockQuoteAsync(string symbol)
        {
			Bloomberg.StockQuote result = null;
            var sw = new Stopwatch();
			sw.Start();  

            try
            {
				var quote = new StockQuoteServiceClient();
				quote.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20);
				result = quote.GetStockQuote(symbol.Trim());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }   
            finally 
            {
				sw.Stop ();                
				var last = 0.0;
				var qresult = double.TryParse (result.Last, out last);
				var qlast = qresult ? last.ToString ("C") : "N/A";
				Console.WriteLine ("{0, -40} | Symbol [{1, -6}] | Last [{2, -10}] | Elapsed time: [{3}ms]",
					string.IsNullOrEmpty (result.Name) ? "Market Quote " : result.Name, result.Symbol, qlast, sw.ElapsedMilliseconds);            
			}
        }

        
        static void Main(string[] args)
        {
			Action<string> action = (string symbol) =>
            {
				GetStockQuoteAsync(symbol);                
            };
            
            try
            {
                StartQuoteBox(action);
                Console.WriteLine("Exiting QuoteBox...");
            }
			catch(Exception ex) 
			{
				Console.WriteLine (ex.Message);
			}
        }

        static void DisplayQuotes(List<StockQuote> quotes)
        {
            foreach (var result in quotes)
            {
                var last = 0.0;
                var qresult = double.TryParse(result.Last, out last);
                var qlast = qresult ? last.ToString("C") : "N/A";
                Console.WriteLine("{0, -40} | Symbol [{1, -6}] | Last [{2, -10}] | Elapsed time: [{3}ms]",
                    string.IsNullOrEmpty(result.Name) ? "Market Quote " : result.Name, result.Symbol, qlast, result.ElapsedMilliseconds);            
            }
        }

        private static void StartQuoteBox(Action<string> action)
        {
            var qs = new QuoteService();
            var someValue = "-q";
            do
            {
				Console.WriteLine("Enter one or more comma seperated stock symbol(s) for quote(s)\nor -nasdaq | -djia to use a default symbol set\nor type -q to exit.");
				someValue = Console.ReadLine();
                
                if (someValue != "-q" && !string.IsNullOrEmpty(someValue))
                {
                    var quotes = qs.GetStockQuoteAsync(someValue, false);
                    DisplayQuotes(quotes.Result);      
                }

            } while (someValue != "-q");			
        }		
        /*
        private static void StartQuoteBox(Action<string> action)
        {
            var someValue = "-q";
            do
            {
                Console.WriteLine("Enter one or more comma seperated stock symbol(s) for quote(s)\nor -nasdaq | -djia to use a default symbol set\nor type -q to exit.");
                someValue = Console.ReadLine();

                if (someValue != "-q" && !string.IsNullOrEmpty(someValue))
                {
                    var symbols = someValue.Split(',');

                    if (someValue.StartsWith("-nasdaq"))
                        symbols = SymbolLibrary.StockSymbols;
                    else if (someValue.StartsWith("-djia"))
                        symbols = SymbolLibrary.DJIA30;

                    Parallel.ForEach(symbols, x => action(x));                    
                }

            } while (someValue != "-q");

            Console.WriteLine("Exiting QuoteBox...");
        }       */
    }
}
