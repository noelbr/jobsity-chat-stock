using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Chat;
using jobsity_stockWorker.Services.Chat.Requests;
using Moq;
using Moq.Protected;
using Xunit;

namespace jobsity_stockWorker.Test.IntegrationTest
{
    public class ChatClientIntegrationTest
    {
        [Fact]
        public async Task SendMesssage()
        { 
            
            // Instantiate the mock object
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(""),
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);


            AppSettings appSettings = new AppSettings
            {
                StockAPI = "http://teste"
            };

            ChatClient chatClient = new ChatClient(appSettings, httpClient);



            var result = await chatClient.SendStock(new StockRequest {

                Name = "APP.US",
                Quote = 99,
                RoomName = "CHATROOM"
            });

            Assert.True(result);


        }
    }
}
