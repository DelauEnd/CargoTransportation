using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CargoTransportation
{
    public class AuthenticatedUserInfo
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }
}