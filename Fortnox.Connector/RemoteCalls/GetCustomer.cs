//using FortnoxAPILibrary;
//using FortnoxAPILibrary.Connectors;

//namespace Webcrm.Integrations.Fortnox.Connector.RemoteCalls
//{
//    internal class GetCustomer
//    {

//        public Customer Get(string customerNumber)
//        {
//            var connector = new CustomerConnector
//            {
//                AccessToken = ApplicationSettings.FortnoxAccessToken,
//                ClientSecret = ApplicationSettings.FortnoxClientSecret
//            };

//            //logger.Debug($"Getting customer {customerNumber}");

//            var customer = connector.Get(customerNumber);
//            return customer;
//        }
//    }
//}
