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
        public string _baseURL;
        HttpClient client = new HttpClient();


        public ChatClient(AppSettings appSettings, HttpClient httpClient = null)
        {
            _baseURL = appSettings.ChatAPI;
            client = httpClient == null ? new HttpClient() : httpClient;
        }



        public async Task<bool> SendStock(StockRequest stockRequest)
        {
            try
            {



                string jsonContent = JsonConvert.SerializeObject(stockRequest,
                                                                new JsonSerializerSettings
                                                                {
                                                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                                });

                var requestContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                requestContent.Headers.Remove("Content-Type");
                requestContent.Headers.Add("Content-Type", "application/json");


                var result = await client.PostAsync(_baseURL, requestContent);

                Console.WriteLine("Chat API Response => " + result.IsSuccessStatusCode.ToString());


                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chat API Response => " + ex.Message);
                return false;

            }

        }
    }
}
