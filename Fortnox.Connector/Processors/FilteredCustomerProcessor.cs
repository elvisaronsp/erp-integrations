using System.Collections.Generic;
using Webcrm.Integrations.Fortnox.Connector.Models;
using Webcrm.Integrations.Fortnox.Connector.RemoteCalls;

namespace Webcrm.Integrations.Fortnox.Connector.Processors
{
    public class FilteredCustomerProcessor
    {
        public List<FilteredCustomer> Process()
        {
            var filter = new FilteredCustomers();
            var allCustomers = new List<FilteredCustomer>();

            //We need to do paging as there is a limit on number of customers
            //  fortnox brings back
            var pageNo = 1;
            var model = filter.All(pageNo);
            while (pageNo < model.MetaInformation.TotalPages)
            {
                allCustomers.AddRange(model.Customers);

                if (pageNo++ <= model.MetaInformation.TotalPages)
                    model = filter.All(pageNo);
            }
            allCustomers.AddRange(model.Customers);

            return allCustomers;
        }


    }
}
