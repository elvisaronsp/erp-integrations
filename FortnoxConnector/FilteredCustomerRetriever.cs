using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Webcrm.Integrations.FortnoxConnector.Models;

namespace Webcrm.Integrations.FortnoxConnector
{
    /// <summary>
    /// NOTE: When we do any kind of querying for customers we get a subset of the 
    ///   full customer. 
    /// </summary>
    public class FilteredCustomerRetriever
    {
        private readonly string accessToken;
        private readonly string clientSecret;

        private readonly RestClient client =
            new RestClient(ApplicationSettings.FortnoxBaseApiUrl);

        private RestRequest Request(string url, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access-token", accessToken);
            request.AddHeader("client-secret", clientSecret);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public FilteredCustomerRetriever(string accessToken, string clientSecret)
        {
            this.accessToken = accessToken;
            this.clientSecret = clientSecret;
        }

        //TODO RHW we need to add in a date last updated here. So we can
        //  get a list of filtered customers who have been created or updated
        //  from fortnox since a given date/time
        public List<FilteredCustomer> Process()
        {
            var allCustomers = new List<FilteredCustomer>();

            //We need to do paging as there is a limit on number of customers
            //  fortnox brings back
            var pageNo = 1;
            var model = Get(pageNo);
            while (pageNo < model.MetaInformation.TotalPages)
            {
                allCustomers.AddRange(model.Customers);

                if (pageNo++ <= model.MetaInformation.TotalPages)
                    model = Get(pageNo);
            }
            allCustomers.AddRange(model.Customers);

            return allCustomers;
        }

        private FilteredCustomers Get(int page)
        {
            const int limit = ApplicationSettings.FortnoxPageLimit;

            var request = Request($"customers?" +
                                  $"filter=active" +
                                  $"&sortby=customernumber" +
                                  $"&sortorder=ascending" +
                                  $"&limit={limit}" +
                                  $"&page={page}",
                Method.GET);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<FilteredCustomers>(response.Content);
        }
    }
}
