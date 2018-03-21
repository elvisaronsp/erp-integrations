using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxAPILibrary;
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
        [FunctionName("FilteredFunctions")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post",
                Route = "fortnox/customers/filtered")]HttpRequest req, TraceWriter log)
        {
            log.Info("Function FilteredFunctions called");

            var connector = new FilteredCustomerProcessor();
            var model = connector.Process();

            //We now have a list of ALL filtered customers. 
            var names = string.Join(", ", model.Select(person => person.Name));
            return new OkObjectResult($"FORTNOX CUSTOMERS: {names}.");
        }

        //private static async Task Process(FilteredCustomersModel model)
        //{
        //    //TODO RJW How do I get instance of log
        //    //log.Debug($"Customers found: {model.Customers.Count}");
        //    foreach (var customer in model.Customers)
        //    {
        //        //logger.Debug($"Found customer so getting full record: {customer.CustomerNumber}");
        //        var fullCustomer = await GetCustomer.Get(customer.CustomerNumber);
        //    }

        //}

    }
}
