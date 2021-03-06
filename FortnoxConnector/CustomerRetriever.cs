using Newtonsoft.Json;
using RestSharp;
using Webcrm.Integrations.FortnoxConnector.Models;

namespace Webcrm.Integrations.FortnoxConnector
{
    public class CustomerRetriever
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

        public CustomerRetriever(string accessToken, string clientSecret)
        {
            this.accessToken = accessToken;
            this.clientSecret = clientSecret;
        }

        public Customer Process(string customernumber)
        {
            var request = Request($"customers/{customernumber}",
                Method.GET);
            var response = client.Execute(request);

            //Fortnox returns a json in the format where we have a customer object
            return JsonConvert
                .DeserializeObject<FortnoxCustomer>(response.Content)
                .Customer;  
        }
    }
}
