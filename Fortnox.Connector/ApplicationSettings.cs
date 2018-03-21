
namespace Webcrm.Integrations.Fortnox.Connector
{
    //TODO RJW NEED TO WORK OUT WHERE THESE END UP as they will be different per 
    //  WebCRM instance
    internal class ApplicationSettings
    {
        //Fortnox API KEYS
        public const string FortnoxBaseApiUrl = "https://api.fortnox.se/3";
        public const string FortnoxAccessToken = "**REMOVED**";
        public const string FortnoxClientSecret = "**REMOVED**";
        //Max of 500, as Fortnox pages data back to us.
        public const int FortnoxPageLimit = 3;

    }
}
