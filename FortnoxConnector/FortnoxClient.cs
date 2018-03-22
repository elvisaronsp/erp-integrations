using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.FortnoxConnector.Models;
using Webcrm.Integrations.FortnoxConnector.Processors;

namespace Webcrm.Integrations.FortnoxConnector
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
                var customer = fullCustomerList.Process(filteredCustomer.CustomerNumber);
                list.Add(customer);
                logger.Info($"{customer.CustomerNumber} - {customer.Name}");
            }

            return list;
        }
    }
}
