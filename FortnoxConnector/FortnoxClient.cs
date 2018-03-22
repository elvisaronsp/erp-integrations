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

        public Customer GetCustomer(string customerNumber)
        {
            logger.Info($"Called GetCustomer with customerNumber {customerNumber}");
            var customer = new CustomerProcessor(accessToken, clientSecret);
            return customer.Process(customerNumber);
        }
    }
}
