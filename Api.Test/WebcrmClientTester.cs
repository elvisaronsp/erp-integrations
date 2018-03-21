using RestSharp;
using System;
using Xunit;

namespace Webcrm.Integrations.Api.Test
{
    public class WebcrmClientTester
    {
        [Fact]
        public void GetFirstTenPeolpleReturnsTenNames()
        {
            var client = new RestClient("http://localhost:7071/");
            var request = new RestRequest("api/TestWebcrmClient");
            var response = client.Execute(request);
            string[] personNames = response.Content.Split(",");

            Assert.Equal(10, personNames.Length);
        }
    }
}
