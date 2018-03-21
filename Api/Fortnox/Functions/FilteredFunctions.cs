using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Fortnox.Connector.Processors;

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

            var connector = new FilteredCustomerProcessor();
            var model = connector.Process();

            //We now have a list of ALL filtered customers. 
            var names = string.Join(", ", model.Select(person => person.Name));
            return new OkObjectResult($"FORTNOX CUSTOMERS: {names}.");
        }

        [FunctionName("FortnoxCustomersInitialSyncToWebCrm")]
        public static IActionResult FortnoxCustomersInitialSyncToWebCrm(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post",
                Route = "fortnox/customers/inital/sync/to/webcrm")]HttpRequest req, TraceWriter log)
        {
            log.Info("Function FilteredFunctions called");

            var connector = new InitialCustomerSyncToWebCrm(log);
            connector.Process();

            //We now have a list of ALL filtered customers. 
            //var names = string.Join(", ", model.Select(person => person.Name));
            return new OkObjectResult($"FORTNOX INITIAL SYNC: Running.");
        }



    }
}
