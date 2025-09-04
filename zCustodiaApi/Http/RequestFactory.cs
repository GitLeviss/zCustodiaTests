using System.Net.Http.Headers;
using zCustodiaApi.Config;

namespace zCustodiaApi.Http;

public static class RequestFactory
{
    private static readonly HttpClient _client;

    static RequestFactory()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(ApiEnvironmentConfig.Get("base.url.custodia"))
        };

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static HttpClient Client => _client;
}
