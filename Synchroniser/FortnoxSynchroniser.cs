using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Webcrm.Integrations.FortnoxConnector;
using Webcrm.Integrations.WebcrmConnector;

namespace Webcrm.Integrations.Synchroniser
{
    public class FortnoxSynchroniser
    {
        private readonly TraceWriter logger;
        private readonly FortnoxClient fortnoxClient;
        private readonly WebcrmClient webcrmClient;

        public FortnoxSynchroniser(TraceWriter logger,
            string webcrmKey,
            string fortnoxAccessToken,
            string fortnoxClientSecret)
        {
            this.logger = logger;
            fortnoxClient = new FortnoxClient(logger, fortnoxAccessToken, fortnoxClientSecret);
            webcrmClient = new WebcrmClient(webcrmKey);
        }

        public void InitialOrganisationSynchroniser(string customerNumber, string webcrmSyncCustomField)
        {
            //First get the fortnox customer
            var customer = fortnoxClient.GetCustomer(customerNumber);

            //TODO What happens if we do not find a fortnox customer?
            if (customer == null)
                return;

            logger.Info($"Found and retrieved fortnox customer from {customer.CustomerNumber}");

            //Now get the corresponding webcrm OrganisationId 
            var webcrmOrganisationId = webcrmClient.GetSingleOrganisationByCustomField(
                    webcrmSyncCustomField, customerNumber)
                .Result;

            //Lets update the organisation
            if (webcrmOrganisationId > 0)
            {
                var webCrmOrganisation = webcrmClient
                    .GetOrganisationBySystemId(webcrmOrganisationId)
                    .Result;

                //map fortnox customer to webcrm organisation
                webCrmOrganisation.OrganisationName = customer.Name;
                webCrmOrganisation.OrganisationAddress = customer.ConcatenatedAddress();
                webCrmOrganisation.OrganisationPostCode = customer.Postcode;
                webCrmOrganisation.OrganisationCity = customer.City;
                webCrmOrganisation.OrganisationCountry = customer.Country;
                webCrmOrganisation.OrganisationWww = customer.Website;
                //TODO I know Andreas wanted to create an invoice EMAIL address on the
                //  organisation record. Therefore this asks another question regarding
                //  whether we have custom mappings for this?
                //webCrmOrganisation.XXX = customer.Email;
                webCrmOrganisation.OrganisationTelephone = customer.Phone1;
                webCrmOrganisation.OrganisationWww = customer.Website;

                Task.Run(async () =>
                    await webcrmClient.SaveOrganisation(webCrmOrganisation))
                        .GetAwaiter()
                        .GetResult();

            }

            //NOTES FOR RJW Now we need to do the following
            //GET customer from webcrm BY custom field number
            // IF customer does not exist then
            //  Get customer by name? by other means
            //   create customer in webcrm
            // ELSE
            //   update customer in webcrm
        }
    }
}
