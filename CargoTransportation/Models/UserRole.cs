using Newtonsoft.Json;

namespace CargoTransportation.Models
{
    public class UserRole
    {
        [JsonProperty("login")]
        public string UserName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
