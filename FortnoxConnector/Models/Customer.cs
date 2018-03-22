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
    }

    //Only used when we deserialise the json from fortnox as they return the payload
    // in a slightly convulated way
    public class FortnoxCustomer
    {
        public Customer Customer { get; set; }
    }

}
