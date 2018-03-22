namespace Webcrm.Integrations.Api.Models
{
    public class SynchroniseOrganisationBody : ApiKey
    {
        public string WebCrmSyncCustomField { get; set; }
    }

    public class ApiKey
    {
        public string WebcrmKey { get; set; }
        public string FortnoxAccessToken { get; set; }
        public string FortnoxClientSecret { get; set; }
        public string FortnoxCustomerNumber { get; set; }
    }
}
