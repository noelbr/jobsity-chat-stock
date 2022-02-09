using System;
using System.Net.Http;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Chat.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace jobsity_stockWorker.Services.Chat
{
    public class ChatClient
    {
        public async Task SendStock(StockRequest stockRequest)
        {


            HttpClient client = new HttpClient();

            string jsonContent = JsonConvert.SerializeObject(stockRequest,
                                                            new JsonSerializerSettings
                                                            {
                                                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                            });

            var requestContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            requestContent.Headers.Remove("Content-Type");  
            requestContent.Headers.Add("Content-Type", "application/json");


           var result = await client.PostAsync("http://chat/api/stock", requestContent);
             
            Console.WriteLine("Chat API Response => " + result.IsSuccessStatusCode.ToString());

        }
    }
}
