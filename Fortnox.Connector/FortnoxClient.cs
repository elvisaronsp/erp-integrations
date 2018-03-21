using System.Collections.Generic;
using Webcrm.Integrations.Fortnox.Connector.Models;
using Webcrm.Integrations.Fortnox.Connector.Processors;

namespace Webcrm.Integrations.Fortnox.Connector
{
    public class FortnoxClient
    {
        private readonly string accessToken;
        private readonly string clientSecret;

        public FortnoxClient(string accessToken, string clientSecret)
        {
            this.accessToken = accessToken;
            this.clientSecret = clientSecret;
        }

        public List<FilteredCustomer> GetAllCustomers()
        {
            return new FilteredCustomerProcessor(accessToken, clientSecret)
                .Process();
        }



    }

}
