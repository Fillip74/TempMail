using System.Text.Json.Serialization;

namespace TempMail.Models
{
    public class AccountInfo
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}