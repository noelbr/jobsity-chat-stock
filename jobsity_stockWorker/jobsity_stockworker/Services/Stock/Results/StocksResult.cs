using System;
using System.Collections.Generic;

namespace jobsity_stockWorker.Services.Stock.Results
{
    public class StocksResult
    {
        public string Symbol { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public int Volume { get; set; }

        public static List<StocksResult> FromCSV (string content)
        {
            List<StocksResult> stocksResults = new List<StocksResult>();

            string[] lines = content.Split(
                 new string[] { "\r\n", "\r", "\n" },
                 StringSplitOptions.None
             );

            for (int i = 1; i < lines.Length; i++)
            {
                var cels = lines[i].Split(",");

                if (cels.Length == 8)
                {
                    StocksResult stocksResult = new StocksResult();

                    stocksResult.Symbol = cels[0];
                    stocksResult.Date = cels[1];
                    stocksResult.Time = cels[2];
                    stocksResult.Open = float.Parse(cels[3]);
                    stocksResult.High = float.Parse(cels[4]);
                    stocksResult.Low = float.Parse(cels[5]);
                    stocksResult.Close = float.Parse(cels[6]);
                    stocksResult.Volume = int.Parse(cels[7]);

                    stocksResults.Add(stocksResult);
                }
            }

            return stocksResults;

        }

    }
}

 