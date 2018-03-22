using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Webcrm.Integrations.WebcrmConnector.Models;

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

        public async Task<int> GetSingleOrganisationByCustomField(
            string customField,
            string value)
        {
            var client = new WebcrmSdk(ApplicationSettings.WebCrmBaseApiUrl);
            var tokensResponse = await client.AuthApiLoginPostAsync(ApiKey);
            if (tokensResponse.StatusCode != "200")
            {
                throw new ApplicationException($"Error fetching application token. {tokensResponse.StatusCode}: {tokensResponse.Result.ErrorDescription}");
            }

            client.AccessToken = tokensResponse.Result.AccessToken;

            var selectOrganisationByCustomField = $@"SELECT OrganisationId 
                        FROM organisation
                        WHERE {customField} = '{value}'";

            var organisationResult = await client.QueriesGetAsync(
                selectOrganisationByCustomField, 1, 1);

            //An organisation could not be found with the correct 
            //  fortnox Key. Therefore we will return 0
            if (organisationResult.Result.Count == 0)
            {
                return 0;
            }

            var organisation = JsonConvert.DeserializeObject<Organisation>(
                organisationResult.Result[0].ToString());

            return organisation.OrganisationId;
        }
    }
}
