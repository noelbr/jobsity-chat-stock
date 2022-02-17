using System;
using System.Linq;
using jobsity_stockWorker.Services.Stock.Results;
using Xunit;

namespace jobsity_stockWorker.Test.UnitTest
{
    public class StockResultUnitTest
    {
        [Fact]
        public void ParseFromCSV()
        {

            StocksResult stocksResult = new StocksResult {
                Symbol = "AAP.US",
                Date = "2022-02-17",
                Time = "15:35:55",
                Open = 171.03F,
                High = 171.54F,
                Low = 170.74F,
                Close = 171.54F,
                Volume = 2099716  
            };

            string content = @"Symbol,Date,Time,Open,High,Low,Close,Volume
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716";
            var convertedObject = StocksResult.FromCSV(content);


            Assert.Single(convertedObject);

            Assert.Equal(stocksResult.Symbol, convertedObject[0].Symbol);
            Assert.Equal(stocksResult.Date, convertedObject[0].Date);
            Assert.Equal(stocksResult.Time, convertedObject[0].Time);
            Assert.Equal(stocksResult.Open, convertedObject[0].Open);
            Assert.Equal(stocksResult.High, convertedObject[0].High);
            Assert.Equal(stocksResult.Low, convertedObject[0].Low);
            Assert.Equal(stocksResult.Close, convertedObject[0].Close);


        }

        [Fact]
        public void ParseFromCSV_listArray()
        {

            string content = @"Symbol,Date,Time,Open,High,Low,Close,Volume
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716";
            var convertedObject = StocksResult.FromCSV(content);


            Assert.Equal(4,convertedObject.Count());

             


        }
    }
}
