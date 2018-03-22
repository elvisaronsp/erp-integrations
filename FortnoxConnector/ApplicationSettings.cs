namespace Webcrm.Integrations.FortnoxConnector
{
    internal class ApplicationSettings
    {
        public const string FortnoxBaseApiUrl = "https://api.fortnox.se/3";

        //Max of 500, as Fortnox pages data back to us.
        public const int FortnoxPageLimit = 100;
    }
}
