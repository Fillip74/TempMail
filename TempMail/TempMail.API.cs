using System.Net.Http.Headers;

namespace TempMail
{
    public sealed partial class MailClient
    {
        private static HttpClient _httpClient;
        private static Uri _apiUri;

        public string Email { get; private set; }
        public string Token { get; private set; }

        static MailClient()
        {
            _httpClient = new HttpClient();
            _apiUri = Endpoints.BaseApiUri;

            SetHeaders(_httpClient);
        }

        private static void SetHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0");
        }

        private Uri FormatUri(string endpoint, params object[] param)
        {
            return new Uri(_apiUri, param == null ? endpoint : string.Format(endpoint, param));
        }
    }
}