using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.Fortnox.Connector.RemoteCalls;
using Webcrm.Integrations.WebcrmConnector.RemoteCalls;
﻿using Microsoft.Azure.WebJobs.Host;

namespace Webcrm.Integrations.Fortnox.Connector.Processors
{
    public class InitialCustomerSyncToWebCrm
    {
        private readonly TraceWriter logger;
        //private readonly GetCustomer getCustomer = new GetCustomer();
        //private readonly Base b = new Base();

        //TODO RJW surely I can inject an ILogger here!
        public InitialCustomerSyncToWebCrm(TraceWriter logger)
        {
            this.logger = logger;
        }

        public void Process()
        {
            //var list = GetFullCustomerList();
            //foreach (var customer in list)
            //{
            //}

            ////var personsResponse = b.Connect();
            //logger.Info(personsResponse.Result.AccessToken);
        }

        //private List<Customer> GetFullCustomerList()
        //{

        //    //Get list of ALL customers using the filtered API endpoint
        //    var filteredCustomers = new FilteredCustomerProcessor().Process();
        //    var fullCustomers = new List<Customer>();

        //    foreach (var filteredCustomer in filteredCustomers)
        //    {
        //        var fullCustomer =
        //            getCustomer.Get(filteredCustomer.CustomerNumber);

        //        fullCustomers.Add(fullCustomer);

        //        logger.Info($"Getting full customer {fullCustomer.CustomerNumber} - {fullCustomer.Name}");
        //    }

        //    return fullCustomers;

        //}
    }
}

//PASS KEYS AROUND LIKE TRAMP DATA
