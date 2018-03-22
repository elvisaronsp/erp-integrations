using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webcrm.Integrations.FortnoxConnector.Models
{

    //TODO RJW
    //For a full list of available fields see
    //https://github.com/FortnoxAB/csharp-api-sdk/blob/master/FortnoxAPILibrary/Entities/Customer.cs
    //https://developer.fortnox.se/documentation/resources/customers/
    public class Customer
    {
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        [JsonProperty("WWW")]
        public string Website { get; set; }

        public string ConcatenatedAddress(string seperator = "\n")
        {
            var addressLines = new List<string>();
            if (!string.IsNullOrWhiteSpace(Address1))
                addressLines.Add(Address1);
            if (!string.IsNullOrWhiteSpace(Address2))
                addressLines.Add(Address2);
            return string.Join(seperator, addressLines);
        }
    }

    //Only used when we deserialise the json from fortnox as they return the payload
    // in a slightly convulated way
    public class FortnoxCustomer
    {
        public Customer Customer { get; set; }
    }

}
