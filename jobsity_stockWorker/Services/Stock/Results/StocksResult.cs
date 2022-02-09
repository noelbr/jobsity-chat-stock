using System;
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
    }
}

 