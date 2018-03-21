using System.Collections.Generic;
using Webcrm.Integrations.Fortnox.Connector;
using Webcrm.Integrations.Fortnox.Connector.Models;

namespace Webcrm.Integrations.Synchroniser
{
    public class FortnoxSynchroniser
    {
        private readonly FortnoxClient fortnoxClient;

        public FortnoxSynchroniser(
            string webCrmKey,
            string fortnoxAccessToken,
            string fortnoxClientSecret)
        {
            fortnoxClient =
                new FortnoxClient(fortnoxAccessToken, fortnoxClientSecret);

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
