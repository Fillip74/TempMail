namespace TempMail
{
    internal static class Endpoints
    {
        public static readonly Uri BaseApiUri = new Uri("https://api.internal.temp-mail.io");

        public const string CreateAccount = "/api/v3/email/new";
        public const string GetDomains = "/api/v4/domains";
        public const string GetMessages = "/api/v3/email/{0}/messages";
    }
}