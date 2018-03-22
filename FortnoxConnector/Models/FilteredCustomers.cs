using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webcrm.Integrations.FortnoxConnector.Models
{
    //Filertered customers are returned to us when we do any kind
    //  of search. When we query fortnox API for records they return
    //  us a subset of the actual customer record. 
    //The key field we then use to look up a full customer is CustomerNumber
    public class FilteredCustomers
    {
        public MetaInformation MetaInformation { get; set; }
        public List<FilteredCustomer> Customers { get; set; }
    }

    public class FilteredCustomer
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string OrganisationNumber { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
    }

    public class MetaInformation
    {
        [JsonProperty("@TotalResources")]
        public int TotalResources { get; set; }

        [JsonProperty("@TotalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("@CurrentPage")]
        public int CurrentPage { get; set; }
    }
}
