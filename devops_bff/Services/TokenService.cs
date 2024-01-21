using System.Net.Http.Json;

namespace devops_bff.Services
{
    public interface ITokenService
    {
        public Task<String> GetTokenAsync(String audience, String clientId);
    }
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TokenService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<String> GetTokenAsync(String audience, String clientId)
        {
            var tokenClient = _httpClientFactory.CreateClient();

            var authBaseAddress = _configuration["Auth:Authority"];
            tokenClient.BaseAddress = new Uri(uriString: authBaseAddress!);

            var tokenParams = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _configuration[clientId]! },
                { "client_secret", _configuration["Auth:ClientSecret"]! },
                { "audience", _configuration[audience]! },
            };

            var tokenForm = new FormUrlEncodedContent(tokenParams);

            var tokenResponse = await tokenClient.PostAsync("oauth/token", tokenForm);

            tokenResponse.EnsureSuccessStatusCode();

            var tokenInfo = await tokenResponse.Content.ReadFromJsonAsync<TokenResponse>();

            if (tokenInfo != null)
            {
                return tokenInfo.access_token;
            }
            else
            {
                throw new Exception("Failed to retrieve token information.");
            }
        }
    }

    public class TokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
    }


}