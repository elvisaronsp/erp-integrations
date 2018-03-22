using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Api.Models;
using Webcrm.Integrations.Synchroniser;

namespace Webcrm.Integrations.Api.Fortnox.Functions
{

    /*PAYLOAD EXPECTED PUT /Api/SynchroniseOrganisationFromFortnox
    {
        FortnoxAccessToken: ...
        FortnoxClientSecret: ...
        WebcrmKey: ...
        FortnoxCustomerNumber: ...
        WebCrmSyncCustomField: ...
    }*/
    public static class SynchroniseOrganisation
    {
        //Notice the trigger was changed from HttpRequest to HttpRequestMessage
        [FunctionName("SynchroniseOrganisationFromFortnox")]
        public static async Task<IActionResult> FromFortnox(
            [HttpTrigger(AuthorizationLevel.Function, "put",
                Route = "SynchroniseOrganisationFromFortnox")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Function SynchroniseOrganisationFromFortnox called");

            var body = await req.Content.ReadAsAsync<SynchroniseOrganisationBody>();

            var synchroniser = new FortnoxSynchroniser(
                log,
                body.WebcrmKey,
                body.FortnoxAccessToken,
                body.FortnoxClientSecret);

            synchroniser.InitialOrganisationSynchroniser(
                body.FortnoxCustomerNumber,
                body.WebCrmSyncCustomField);
            return new OkObjectResult("Function SynchroniseOrganisationFromFortnox ran");
        }
    }
}
