using RestSharp;
using System;
using System.Collections.Generic;
using Webcrm.Integrations.PowerofficeConnector.Models;

namespace Webcrm.Integrations.PowerofficeConnector
{
    public class PowerofficeClient
    {
        public PowerofficeClient(
            string applicationKey,
            string clientKey)
        {
            ApplicationKey = applicationKey;
            ClientKey = clientKey;
        }

        private const string baseApiUrl = "https://api-demo.poweroffice.net/";
        private const string baseAuthenticationUrl = "https://godemo.poweroffice.net/";

        private string ApplicationKey { get; }
        private string ClientKey { get; }

        public List<Customer> GetCustomers()
        {
            var client = new RestClient(baseAuthenticationUrl);

            string encodedKeys = Base64Encode($"{ApplicationKey}:{ClientKey}");

            var tokensRequest = new RestRequest("OAuth/Token", Method.POST);
            tokensRequest.AddHeader("Authorization", encodedKeys);
            tokensRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            tokensRequest.AddBody("grant_type=client_credentials");

            var tokensResponse = client.Execute<AuthorizationTokens>(tokensRequest);

            client.BaseUrl = new System.Uri(baseApiUrl);
            var customersRequest = new RestRequest("Customer/", Method.GET);
            customersRequest.AddHeader("Authorization", tokensResponse.Data.access_token);

            var rawCustomersResponse = client.Execute(customersRequest);

            var cutomersResponse = client.Execute<List<Customer>>(customersRequest);

            return cutomersResponse.Data;
        }

        private static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string encodedText = System.Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }
    }
}
