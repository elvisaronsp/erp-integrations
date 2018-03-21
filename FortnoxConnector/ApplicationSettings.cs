namespace Webcrm.Integrations.FortnoxConnector
{
    internal class ApplicationSettings
    {
        public const string FortnoxBaseApiUrl = "https://api.fortnox.se/3";

        //Max of 500, as Fortnox pages data back to us.
        //TODO RJW this should be higher, 100 or so!
        public const int FortnoxPageLimit = 3;

    }
}
