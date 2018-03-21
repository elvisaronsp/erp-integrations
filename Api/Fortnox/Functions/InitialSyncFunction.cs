using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Synchroniser;

namespace Webcrm.Integrations.Api.Fortnox.Functions
{
    public static class InitialSyncFunction
    {
        [FunctionName("FortnoxCustomersInitialSyncToWebCrm")]
        public static IActionResult FortnoxCustomersInitialSyncToWebCrm(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post",
                Route = "fortnox/customers/inital/sync/to/webcrm")]HttpRequest req, TraceWriter log)
        {
            log.Info("Function FilteredFunctions called");

            Synchroniser.InitialCustomerSync();
            return new OkObjectResult($"FORTNOX INITIAL SYNC: Running....");
        }

        //TODO RJW normally I woudl use a base class
        private static FortnoxSynchroniser Synchroniser => new FortnoxSynchroniser(
            ApiKeys.B2bTestSystemFullAccessAppToken,
            ApiKeys.FortnoxAccessToken,
            ApiKeys.FortnoxClientSecret);


    }
}
