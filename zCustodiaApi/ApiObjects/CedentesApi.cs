using NUnit.Framework;
using zCustodiaApi.Config;
using zCustodiaApi.Http;
using zCustodiaApi.models.requests.cedentes;

namespace zCustodiaApi.ApiObjects;

/// Representa a API de Cedentes.
public class CedentesApi
{

    public CedentesApi()
    {

    }

    private const string PostEndpoint = "/api/Cedente/Criar";
    private const string GetEndpoint = "/api/Cedente/";
    private const string PutEndpoint = "/api/Cedente/Atualizar";
    private const string DeleteEndpoint = "/api/Cedente/Document-Flows/${idGrupo}";
    private string token = ApiEnvironmentConfig.Get("base.tokens.tokenCustodia");




    public async Task CadastrarCedenteComSucesso(string nome, string senha)
    {

        // Montamos o payload do usuário
        var payload = new Dictionary<string, object>
        {
            { "nomeCompleto", nome },
            { "cpf",  "teste"},
            { "email",  "teste"},
            { "senha",  senha}
        };

        // Fazemos a chamada POST
        var response = await RestClient.PostAsync(PostEndpoint, payload);

        // Assert já dentro do APIObject: valida status 200 ou 201
        Assert.That(response.StatusCode,
                    Is.EqualTo(System.Net.HttpStatusCode.OK).Or.EqualTo(System.Net.HttpStatusCode.Created),
                    $"Falha ao cadastrar usuário. Status retornado: {(int)response.StatusCode}");
    }

    public async Task ConsultarCedenteComSucesso(string id, string testCase)
    {
        var response = await RestClient.GetAsync(GetEndpoint + id, token);
            Utils.Utils.ValidarStatusCode(response, "Validar Status code no Endpoint " +GetEndpoint + " No Teste: " + testCase );        
    }



}
