using Webcrm.Integrations.PowerofficeConnector;
using Webcrm.Integrations.Private;
using Xunit;

namespace Webcrm.Integrations.PowerofficeConnector.Test
{
    public class PowerofficeClientTester
    {
        [Fact]
        public void GetCustomersReturnsCustomers()
        {
            var client = new PowerofficeClient(ApiKeys.PowerOfficeTestApplicationKey, ApiKeys.PowerOfficeTestClientKey);
            var customers = client.GetCustomers();
            Assert.True(customers.Count >= 1);
        }
    }
}
