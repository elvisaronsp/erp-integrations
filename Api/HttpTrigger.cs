using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.IO;

namespace Webcrm.Integrations.Api
{
	public static class HttpTrigger
    {
        [FunctionName("HttpTrigger")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest request,
            TraceWriter log
        ) {
            log.Info("C# HTTP trigger function processed a request.");

            string name = request.Query["name"];

            if (name == null)
            {
                string requestBody = new StreamReader(request.Body).ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = data?.name;
            }

            if (name == null)
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }

            return new OkObjectResult($"Hello, {name}.");
        }
    }
}
