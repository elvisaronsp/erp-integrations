using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Fortnox.Connector.Models;
using Webcrm.Integrations.Fortnox.Connector.Processors;

namespace Webcrm.Integrations.Fortnox.Connector
{
    public class FortnoxClient
    {
        private readonly TraceWriter logger;
        private readonly string accessToken;
        private readonly string clientSecret;

        public FortnoxClient(TraceWriter logger,
            string accessToken,
            string clientSecret)
        {
            this.logger = logger;
            this.accessToken = accessToken;
            this.clientSecret = clientSecret;
        }

        public List<FilteredCustomer> GetAllFilteredCustomers()
        {
            return new FilteredCustomerProcessor(accessToken, clientSecret)
                .Process();
        }


        public List<FullCustomer> GetAllFullCustomers()
        {
            var fullCustomerList = new FullCustomerProcessor(accessToken, clientSecret);

            var list = new List<FullCustomer>();
            foreach (var filteredCustomer in GetAllFilteredCustomers())
            {
                list.Add(fullCustomerList.Process(filteredCustomer.CustomerNumber));
                logger.Info("HERE!");
            }

            return list;
        }
    }

}
