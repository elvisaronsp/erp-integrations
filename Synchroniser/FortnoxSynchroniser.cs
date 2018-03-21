using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Fortnox.Connector;
using Webcrm.Integrations.Fortnox.Connector.Models;

namespace Webcrm.Integrations.Synchroniser
{
    public class FortnoxSynchroniser
    {
        private readonly TraceWriter logger;
        private readonly FortnoxClient fortnoxClient;

        public FortnoxSynchroniser(
            TraceWriter logger,
            string webCrmKey,
            string fortnoxAccessToken,
            string fortnoxClientSecret)
        {
            this.logger = logger;
            fortnoxClient =
                new FortnoxClient(logger, fortnoxAccessToken, fortnoxClientSecret);

            //TODO RJW set up WebCrmClient
        }

        public void InitialCustomerSync()
        {
            var customerList = fortnoxClient.GetAllFullCustomers();
            foreach (var customer in customerList)
            {
                //TODO RJW we need to do the following
                //GET customer from WebCrm BY custom field number
                // IF customer does not exist then
                //  Get customer by name? by other means
                //   create customer in webcrm
                // ELSE
                //   update customer in webcrm
            }
        }

        public List<FilteredCustomer> GetCustomers()
        {
            return fortnoxClient.GetAllFilteredCustomers();
        }
    }
}
