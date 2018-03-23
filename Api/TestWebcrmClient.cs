using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Threading.Tasks;
using Webcrm.Integrations.Api.Models;
using Webcrm.Integrations.WebcrmConnector;

namespace Webcrm.Integrations.Api
{
    public static class TestWebcrmClient
    {
        [FunctionName("TestWebcrmClient")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            HttpRequestMessage req,
            TraceWriter log
        ) {
            TestWebcrmClientRequestBody body = await req.Content.ReadAsAsync<TestWebcrmClientRequestBody>();
            var client = new WebcrmClient(body.WebcrmApplicationToken);
            string personNames = await client.GetTenPersonNames();
            return new OkObjectResult($"First ten persons: {personNames}.");
        }
    }
}
