using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Webcrm.Integrations.Fortnox.Connector;
using Webcrm.Integrations.Fortnox.Connector.Models;

namespace Webcrm.Integrations.Synchroniser
{
    public class FortnoxSynchroniser
    {
        private FortnoxClient fortnoxClient;

        public FortnoxSynchroniser(string webCrmKey, 
            string fortnoxAccessToken, 
            string fortnoxClientSecret)
        {
            fortnoxClient = new FortnoxClient(fortnoxAccessToken, fortnoxClientSecret);
            //TODO RJW set up WebCrmClient
            //FortnoxClient fc, WebCrmClient wc
        }

        public void InitialCustomerSync()
        {
            //fn get clients
            //for each
            //get webcrmcustomer
            //update

        }

        public List<FilteredCustomer> GetCustomers()
        {
            return fortnoxClient.GetAllCustomers();
        }
    }
}
