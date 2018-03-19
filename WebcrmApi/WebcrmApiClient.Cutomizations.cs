using System.Net.Http;
using System.Net.Http.Headers;

namespace Webcrm.Integrations.WebcrmApi
{
    public partial class WebcrmApiClient
    {
        public string AccessToken;

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            if (AccessToken != null) {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }
        }
    }
}
