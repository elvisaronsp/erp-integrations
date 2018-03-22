﻿
namespace Webcrm.Integrations.FortnoxConnector.Models
{

    public class FortnoxCustomer
    {
        public FullCustomer Customer { get; set; }
    }

    //TODO RJW
    //For a full list of available fields see
    //https://github.com/FortnoxAB/csharp-api-sdk/blob/master/FortnoxAPILibrary/Entities/Customer.cs
    //https://developer.fortnox.se/documentation/resources/customers/
    public class FullCustomer
    {
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
    }
}