using System.Text.Json.Serialization;

namespace TempMail.Models
{
    public class DomainsData
    {
        public DomainInfo[] Domains { get; set; }
    }

    public class DomainInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("forward_available")]
        public bool ForwardAvailable { get; set; }

        [JsonPropertyName("forward_max_seconds")]
        public int ForwardMaxSeconds { get; set; }
    }
}