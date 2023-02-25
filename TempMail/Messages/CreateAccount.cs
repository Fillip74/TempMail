using System.Text.Json.Serialization;

namespace TempMail.Messages
{
    public class CreateAccount
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("min_name_length")]
        public int MinLength { get; set; }

        [JsonPropertyName("max_name_length")]
        public int MaxLength { get; set; }
    }
}