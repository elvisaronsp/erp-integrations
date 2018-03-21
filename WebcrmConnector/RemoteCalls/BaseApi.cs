using System;
using System.Threading.Tasks;

namespace Webcrm.Integrations.WebcrmApi.RemoteCalls
{
    public class Base
    {

        //TODO RJW like idea of only getting token if we need one!
        public async Task<WebcrmApiClient> ConnectAsync()
        {
            var client = new WebcrmApiClient(ApplicationSettings.WebCrmBaseApiUrl);

            var tokensResponse = await client.AuthApiLoginPostAsync(
                ApplicationSettings.FullAccessAppToken);

            if (tokensResponse.StatusCode != "200")
            {
                throw new ApplicationException($"Error fetching application token. {tokensResponse.StatusCode}: {tokensResponse.Result.ErrorDescription}");
            }

            client.AccessToken = tokensResponse.Result.AccessToken;
            return client;
        }
    }

    //public class GetCustomerBy
}
