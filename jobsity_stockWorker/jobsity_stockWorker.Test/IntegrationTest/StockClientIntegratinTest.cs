using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Stock;
using Moq;
using Moq.Protected;
using Xunit;

namespace jobsity_stockWorker.Test.IntegrationTest
{
    public class StockClientIntegratinTest
    {
        [Fact]
        public async Task GetListStockRequest()
        {

            string content = @"Symbol,Date,Time,Open,High,Low,Close,Volume
AAP.US,2022-02-17,15:35:55,171.03,171.54,170.74,171.54,2099716";

            // Instantiate the mock object
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content),
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
            
            StockClient stockClient = new StockClient(appSettings, httpClient);



           var result = await stockClient.Get("app.us");

            Assert.Single(result);

 
        }
    }
}
