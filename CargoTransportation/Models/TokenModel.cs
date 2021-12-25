using System.Text.Json.Serialization;

namespace CargoTransportation
{
    public class TokenModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}