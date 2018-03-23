using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;
using Webcrm.Integrations.Private;
using Webcrm.Integrations.WebcrmConnector;

namespace Webcrm.Integrations.Api
{
    public static class TestWebcrmClient
    {
        [FunctionName("TestWebcrmClient")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
            HttpRequest req,
            TraceWriter log
        ) {
            var client = new WebcrmClient(ApiKeys.B2bTestSystemReadOnlyAccessAppToken);
            string personNames = await client.GetTenPersonNames();
            return new OkObjectResult($"First ten persons: {personNames}.");
        }
    }
}
