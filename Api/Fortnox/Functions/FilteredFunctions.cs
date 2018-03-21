using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Synchroniser;

namespace Webcrm.Integrations.Api.Fortnox.Functions
{
    public static class FilteredFunctions
    {

        //TODO RJW Does this need to be async?
        [FunctionName("FortnoxCustomersFilteredAll")]
        public static IActionResult FortnoxCustomersFilteredAll(
            [HttpTrigger(AuthorizationLevel.Function, "get",
                Route = "fortnox/customers/filtered/all")]HttpRequest req, TraceWriter log)
        {
            log.Info("Function FilteredFunctions called");

            var result = Synchroniser.GetCustomers();

            //We now have a list of ALL filtered customers. 
            var names = string.Join(", ", result.Select(person => person.Name));
            return new OkObjectResult($"FORTNOX CUSTOMERS: {names}.");
        }


        //TODO RJW normally I woudl use a base class
        private static FortnoxSynchroniser Synchroniser => new FortnoxSynchroniser(
                ApiKeys.B2bTestSystemFullAccessAppToken,
                ApiKeys.FortnoxAccessToken,
                ApiKeys.FortnoxClientSecret);


    }
}
