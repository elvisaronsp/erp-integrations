using RestSharp;

namespace Webcrm.Integrations.Fortnox.Connector.RemoteCalls
{
    //TODO RJW NEED TO WORK OUT WHERE THESE END UP as they will be different per 
    //  WebCRM instance

    internal class BaseApi
    {

        internal static readonly RestClient Client =
            new RestClient(ApplicationSettings.FortnoxBaseApiUrl);


        internal RestRequest Request(string url, Method method)
        {
            var accessToken = ApplicationSettings.FortnoxAccessToken;
            var clientSecret = ApplicationSettings.FortnoxClientSecret;

            var request = new RestRequest(url, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access-token", accessToken);
            request.AddHeader("client-secret", clientSecret);
            request.AddHeader("Accept", "application/json");
            return request;
        }


    }
}
