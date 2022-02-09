using System;
using System.Net.Http;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Stock.Results;
using Newtonsoft.Json;

namespace jobsity_stockWorker.Services.Stock
{
    public class StockClient
    {

        public async Task<SimbolsResult> Get(string stock) {
           

                HttpClient client = new HttpClient();

                var response = await client.GetAsync("https://stooq.com/q/l/?s="+ stock + "&f=sd2t2ohlcv&h&e=json");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                { 
                    return JsonConvert.DeserializeObject<SimbolsResult>(content);
                }
                else
                { 
                    throw new Exception("fatall get stock erro");
                }  
        }
    }
}
