﻿using Newtonsoft.Json;
using RestSharp;
using Webcrm.Integrations.Fortnox.Connector.Models;

namespace Webcrm.Integrations.Fortnox.Connector.Processors
{
    public class FullCustomerProcessor
    {
        //TODO RJW base class?
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

        public FullCustomerProcessor(string accessToken, string clientSecret)
        {
            this.accessToken = accessToken;
            this.clientSecret = clientSecret;
        }

        public FullCustomer Process(string customernumber)
        {
            var request = Request($"customers/{customernumber}",
                Method.GET);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<FullCustomer>(response.Content);
        }



    }
}
