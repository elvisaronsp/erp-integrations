using System;
using System.Linq;
using System.Threading.Tasks;

namespace Webcrm.Integrations.WebcrmConnector
{
    public class WebcrmClient
    {
        public WebcrmClient(string apiKey)
        {
            ApiKey = apiKey;
        }


        private string ApiKey { get;set; }

        public async Task<string> GetTenPersonNames()
        {
            var client = new WebcrmSdk(ApplicationSettings.WebCrmBaseApiUrl);
            var tokensResponse = await client.AuthApiLoginPostAsync(ApiKey);
            if (tokensResponse.StatusCode != "200")
            {
                throw new ApplicationException($"Error fetching application token. {tokensResponse.StatusCode}: {tokensResponse.Result.ErrorDescription}");
            }

            client.AccessToken = tokensResponse.Result.AccessToken;

            var personsResponse = await client.PersonsGetAsync(1, 10);
            string personNames = String.Join(", ", personsResponse.Result.Select(person => person.PersonName));
            return personNames;
        }
    }
}
