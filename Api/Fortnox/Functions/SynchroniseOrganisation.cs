using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Threading.Tasks;
using Webcrm.Integrations.Api.Models;
using Webcrm.Integrations.Synchroniser;

namespace Webcrm.Integrations.Api.Fortnox.Functions
{
    /// <summary>
    /// Expected body for PUT /Api/Fortnot/SynchroniseOrganisationFromFortnox
    /// <code>
    ///     {
    ///         FortnoxAccessToken: ...
    ///         FortnoxClientSecret: ...
    ///         WebcrmKey: ...
    ///         FortnoxCustomerNumber: ...
    ///         WebcrmSyncCustomField: ...
    ///     }
    /// </code>
    /// </summary>
    public static class SynchroniseOrganisation
    {
        // Notice the trigger was changed from HttpRequest to HttpRequestMessage
        [FunctionName("SynchroniseOrganisationFromFortnox")]
        public static async Task<IActionResult> FromFortnox(
            [HttpTrigger(AuthorizationLevel.Function, "put")]
            HttpRequestMessage req, TraceWriter log)
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
                body.WebcrmSyncCustomField);
            return new OkObjectResult("Function SynchroniseOrganisationFromFortnox ran");
        }
    }
}
