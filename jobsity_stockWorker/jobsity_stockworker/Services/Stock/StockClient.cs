using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Stock.Results;
using Newtonsoft.Json;

namespace jobsity_stockWorker.Services.Stock
{
    public class StockClient
    {
        public string _baseURL;
        HttpClient client = new HttpClient();

        public StockClient(AppSettings appSettings, HttpClient httpClient = null)
        {

            _baseURL = appSettings.StockAPI; 
            client = httpClient == null ? new HttpClient(): httpClient ;
        }


        public async Task<List<StocksResult>> Get(string stock) {
           


                var response = await client.GetAsync(_baseURL+"/q/l/?s=" + stock + "&f=sd2t2ohlcv&h&e=csv");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                { 

                    return StocksResult.FromCSV(content);
                }
                else
                { 
                    throw new Exception("fatall get stock erro");
                }  
        }
    }
}
