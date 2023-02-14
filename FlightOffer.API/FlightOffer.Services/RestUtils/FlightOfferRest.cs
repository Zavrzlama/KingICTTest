using Newtonsoft.Json;
using RestSharp;

namespace FlightOffer.Services.RestUtils
{
    public class FlightOfferRest
    {

        public async Task<T> OpenIdPost<T>(string url, string clientId, string clientSecret)
        {
            var client = new RestClient("https://test.api.amadeus.com/v1/security/oauth2/token");
            var request = OpenIdRequest(clientId, clientSecret);
            var response = await client.PostAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> JwtGet<T>(string url, string jwt)
        {
            var client = new RestClient(url);
            var request = JwtRequest(jwt);
            var response = await client.GetAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public Task<T> JwtPost<T>(string url, string jwt)
        {
            throw new NotImplementedException();
        }

        private RestRequest JwtRequest(string jwt)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {jwt}");

            return request;
        }

        private RestRequest OpenIdRequest(string clientId, string clientSecret)
        {
            var request = new RestRequest();

            string id = $"client_id={clientId}";
            string secret = $"client_secret={clientSecret}";
            string openId = $"grant_type=client_credentials&{id}&{secret}";

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", openId, ParameterType.RequestBody);
            return request;
        }

    }
}
