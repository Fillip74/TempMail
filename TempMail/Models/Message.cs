using System.Text.Json.Serialization;

namespace TempMail.Models
{
    public class Message
    {
        [JsonPropertyName("id")]
        public string Number { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("cc")]
        public object CarbonCopy { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body_text")]
        public string BodyText { get; set; }

        [JsonPropertyName("body_html")]
        public string BodyHtml { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("attachments")]
        public object[] Attachments { get; set; }
    }
}