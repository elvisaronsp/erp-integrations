using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webcrm.Integrations.WebcrmApi;

namespace Webcrm.Integrations.Api
{
    public static class Persons
    {
        [FunctionName("Persons")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "persons")]
            HttpRequest req,
            TraceWriter log
        ) {
            var client = new WebcrmApiClient("https://api.webcrm.com/");

            var tokensResponse = await client.AuthApiLoginPostAsync(ApiKeys.B2bTestSystemReadOnlyAccessAppToken);
            if (tokensResponse.StatusCode != "200")
            {
                throw new ApplicationException($"Error fetching application token. {tokensResponse.StatusCode}: {tokensResponse.Result.ErrorDescription}");
            }

            client.AccessToken = tokensResponse.Result.AccessToken;

            var personsResponse = await client.PersonsGetAsync(1, 10);
            string personNames = String.Join(", ", personsResponse.Result.Select(person => person.PersonName));
            return new OkObjectResult($"First ten persons: {personNames}.");
        }
    }
}
