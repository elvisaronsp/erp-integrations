using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.FortnoxConnector;

namespace Webcrm.Integrations.Synchroniser
{
    public class FortnoxSynchroniser
    {
        private readonly TraceWriter logger;
        private readonly FortnoxClient fortnoxClient;

        public FortnoxSynchroniser(TraceWriter logger,
            string webCrmKey,
            string fortnoxAccessToken,
            string fortnoxClientSecret)
        {
            this.logger = logger;
            fortnoxClient =
                new FortnoxClient(logger, fortnoxAccessToken, fortnoxClientSecret);

            //TODO RJW set up WebCrmClient
        }

        //TODO RJW Talk Jen about error trapping etc
        public void InitialOrganisationSynchroniser(string customerNumber, string webCrmSyncCustomField)
        {
            var customer = fortnoxClient.GetCustomer(customerNumber);
            logger.Info($"Found and retrieved fortnox customer from {customer.CustomerNumber}");

            //Now we need to do the following
            //GET customer from WebCrm BY custom field number
            // IF customer does not exist then
            //  Get customer by name? by other means
            //   create customer in webcrm
            // ELSE
            //   update customer in webcrm
        }
    }
}
