using RestSharp;
using Webcrm.Integrations.Api.Models;
using Webcrm.Integrations.Private;
using Xunit;

namespace Webcrm.Integrations.Api.Test
{
    public class WebcrmClientTester
    {
        [Fact]
        public void GetFirstTenPeolpleReturnsTenNames()
        {
            var client = new RestClient("http://localhost:7071/");

            var request = new RestRequest("Api/TestWebcrmClient", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            TestWebcrmClientRequestBody body = new TestWebcrmClientRequestBody
            {
                WebcrmApplicationToken = ApiKeys.WebcrmB2bReadOnlyAccessAppToken
            };
            request.AddJsonBody(body);

            var response = client.Execute(request);
            string[] personNames = response.Content.Split(",");

            Assert.Equal(10, personNames.Length);
        }
    }
}
