using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task<long> GetSingleOrganisationByCustomField(
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

            //If we cannot find a organisation then we need to create one
            //TODO Question JAN do we make a call here OR from the calling 
            //  method?
            if (organisationResult.Result.Count == 0)
            {
                return 0;
            }

            //TODO Jan is there a better way to extract the OrganisationId here?
            dynamic jsonResult = JsonConvert.DeserializeObject(
                organisationResult.Result[0].ToString());

            var organisationId =
                JObject.Parse(jsonResult.ToString())["OrganisationId"];

            return long.Parse(organisationId);
        }
    }
}
