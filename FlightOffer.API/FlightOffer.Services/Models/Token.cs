using Newtonsoft.Json;

namespace FlightOffer.Services.Models
{
    public class Token
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }
        [JsonProperty("token_type")] public string TokenType { get; set; }
        [JsonProperty("session_state")] public string SessionState { get; set; }
        [JsonProperty("expires_in")] public int ExpiresIn { get; set; }
        [JsonProperty("refresh_expires_in")] public int RefreshExpiresIn { get; set; }
    }
}
