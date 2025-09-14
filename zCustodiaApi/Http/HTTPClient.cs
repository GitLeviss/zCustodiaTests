using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Json;

namespace zCustodiaApi.Http;

/// Classe utilitária para simplificar chamadas HTTP (GET, POST, PUT, DELETE).
public static class HTTPClient
{
    public static async Task<HttpResponseMessage> GetAsync(string endpoint, string? token = null)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            if (!string.IsNullOrWhiteSpace(token))
            {
                // Adiciona o Bearer Token no cabeçalho da requisição
                request.Headers.Add("token", token);
            }

            return await RequestFactory.Client.SendAsync(request);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível enviar requisição GET para o Endpoint: "
                                + endpoint + " | Erro: " + ex.Message, ex);
        }
    }


    public static async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T body, string? token = null)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = JsonContent.Create(body)
            };
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("token", token);
            }
            return await RequestFactory.Client.SendAsync(request);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível enviar requisição POST para o Endpoint: "
                                + endpoint + " | Erro: " + ex.Message, ex);
        }
    }

    public static async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T body, string? token = null)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
            {
                Content = JsonContent.Create(body)
            };
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("token", token);
            }
            return await RequestFactory.Client.SendAsync(request);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível enviar requisição PUT para o Endpoint: "
                                + endpoint + " | Erro: " + ex.Message, ex);
        }
    }

    public static async Task<HttpResponseMessage> DeleteAsync(string endpoint, string? token = null)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("token", token);
            }

            return await RequestFactory.Client.SendAsync(request);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível enviar requisição DELETE para o Endpoint: "
                                + endpoint + " | Erro: " + ex.Message, ex);
        }
    }


    public static async Task<T?> ReadAsAsync<T>(HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<T>();
    }
}
