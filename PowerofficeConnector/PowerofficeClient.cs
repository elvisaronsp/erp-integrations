using System;

namespace Webcrm.Integrations.PowerofficeConnector
{
    public class PowerofficeClient
    {
        public PowerofficeClient(
            string applicationKey,
            string clientKey)
        {
            ApplicationKey = applicationKey;
            ClientKey = clientKey;
        }

        private string ApplicationKey { get; }
        private string ClientKey { get; }
    }
}
