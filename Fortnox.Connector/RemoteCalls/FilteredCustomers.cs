using Newtonsoft.Json;
using RestSharp;
using Webcrm.Integrations.Fortnox.Connector.Models;

namespace Webcrm.Integrations.Fortnox.Connector.RemoteCalls
{
    internal class FilteredCustomers : BaseApi
    {

        // public FilteredCustomersModel ByDate (DateTime update) {

        //     //logger.Debug ($"Calling filter customers ByDate with {update}");

        //     var request = Request ($"customers?filter=active&lastmodified={update:yyyy-MM-dd hh:mm}&limit=500",
        //         Method.GET);
        //     var response = Client.Execute (request);

        //     return JsonConvert.DeserializeObject<FilteredCustomersModel> (response.Content);

        // }

        public FilteredCustomersModel All(int page = 1)
        {
            const int limit = ApplicationSettings.FortnoxPageLimit;

            var request = Request($"customers?" +
                 $"filter=active" +
                 $"&sortby=customernumber" +
                 $"&sortorder=ascending" +
                 $"&limit={limit}" +
                 $"&page={page}",
                 Method.GET);
            var response = Client.Execute(request);

            return JsonConvert.DeserializeObject<FilteredCustomersModel>(response.Content);

        }

    }
}
