using System;
using System.Collections.Generic;
using System.Text;
using Webcrm.Integrations.Fortnox.Connector.Processors;
using Webcrm.Integrations.Fortnox.Connector.RemoteCalls;

namespace Webcrm.Integrations.Fortnox.Connector
{
    public class FortnoxClient
    {
        private readonly string accessToken;
        private readonly string secret;

        public FortnoxClient(string accessToken, string secret)
        {
            this.accessToken = accessToken;
            this.secret = secret;
        }

    }

}
