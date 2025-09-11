using Newtonsoft.Json;
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

    private static string payloadId;
    CadastrarCedentesReq cedentesReq = new CadastrarCedentesReq();

    private const string PostEndpoint = "/api/Cedente/Criar";
    private const string GetEndpoint = "/api/Cedente/";
    private const string PutEndpoint = "/api/Cedente/Atualizar";
    private const string DeleteEndpoint = "/api/Cedente/QATESTE/";
    private string Token = ApiEnvironmentConfig.Get("base.tokens.tokenCustodia");




    public async Task CadastrarCedenteComSucesso(string testCase)
    {
        // Monta o payload do usuário direto, sem wrapper
        var payload = CadastrarCedentesReq.CedenteValido(
            nome: $"CEDENTE {testCase}"
        );

        var response = await HTTPClient.PostAsync(PostEndpoint, payload, Token);

        var responseContent = await response.Content.ReadAsStringAsync();

        // Supondo que a API retorne algo como { "id": 123, "status": "success" }
        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

        // Atribuímos o id ao payloadId
        payloadId = result.id.ToString();

        Utils.Utils.ValidarStatusCode(response,
            "Validar Status code no Endpoint " + GetEndpoint + " No Teste: " + testCase);
        Utils.Utils.ValidarTextoNoJson(response, "id", "Validar Se na Resposta retornou 'id'");
    }
    public async Task CadastrarCedenteJaCadastrado(string testCase, string textoEsperado)
    {
        var payload = CadastrarCedentesReq.CedenteValido(
            nome: $"CEDENTE {testCase}"
        );

        var response = await HTTPClient.PostAsync(PostEndpoint, payload, Token);

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);


        Utils.Utils.ValidarStatusCodeNegativo(response,
            "Validar Status code no Endpoint " + PostEndpoint + " No Teste Negativo: " + testCase);
        Utils.Utils.ValidarTextoNoJson(response, textoEsperado, $"Validar Se na Resposta retornou '{textoEsperado}' ");
    }
    public async Task AtualizarCedenteComSucesso(string testCase)
    {
        // Monta o payload do usuário direto, sem wrapper
        var payload = CadastrarCedentesReq.CedenteValido(
            nome: $"CEDENTE {testCase}",
            mutate: d =>
            {
                d["id"] = payloadId;
                d["email"] = "testeAtualizado@gmail.com";
            }
        );

        var response = await HTTPClient.PutAsync(PutEndpoint, payload, Token);

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

        payloadId = result.id.ToString();

        Utils.Utils.ValidarStatusCode(response,
            "Validar Status code no Endpoint " + GetEndpoint + " No Teste: " + testCase);
    }




    public async Task ConsultarCedenteComSucesso(string testCase)
    {
        var response = await HTTPClient.GetAsync(GetEndpoint + payloadId, Token);
            Utils.Utils.ValidarStatusCode(response, "Validar Status code no Endpoint " +GetEndpoint + " No Teste: " + testCase );        
    }
    public async Task ConsultarCedenteNegativo(string testCase, int id, string msgRetornada)
    {
        var response = await HTTPClient.GetAsync(GetEndpoint + id, Token);
        Utils.Utils.ValidarStatusCodeNegativo(response, "Validar Status code no Endpoint " + GetEndpoint + " No Teste Negativo: " + testCase);
        Utils.Utils.ValidarTextoNoJson(response, msgRetornada, $"Validar Se na Resposta retornou {msgRetornada}");
    }

    public async Task DeletarCedenteComSucesso(string testCase)
    {
        var response = await HTTPClient.DeleteAsync(DeleteEndpoint + payloadId, Token);
            Utils.Utils.ValidarStatusCode(response, "Validar Status code no Endpoint " + DeleteEndpoint + " No Teste: " + testCase );        
            Utils.Utils.ValidarTextoNoJson(response, "Cedente deletado com sucesso.", "Validar Se na Resposta retornou 'Cedente deletado com sucesso'");        
    }

    public async Task CadastrarCedenteNegativo(string testCase, string atributoAlterado, string massaNegativa, string textoEsperado)
    {
        var payload = CadastrarCedentesReq.CedenteValido(
             nome: $"CEDENTE {testCase}",
             d =>
             {
                 d[atributoAlterado] = massaNegativa;
             }
         );

        var response = await HTTPClient.PostAsync(PostEndpoint, payload, Token);

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

        Utils.Utils.ValidarStatusCodeNegativo(response,"Validar Status code no Endpoint " + PostEndpoint + " No Teste Negativo: " + testCase);
        Utils.Utils.ValidarTextoNoJson(response, textoEsperado, $"Validar Se na Resposta retornou '{textoEsperado}' ");

    }

    public async Task CadastrarCedenteNegativoPix(string testCase, string tipoChave, string massaNegativa, string textoEsperado)
    {
        var payload = CadastrarCedentesReq.CedenteValido(
             nome: $"CEDENTE {testCase}",
             d =>
             {
                 d["tipoChavePix"] = tipoChave;
                 d["chavePix"] = massaNegativa;
             }
         );

        var response = await HTTPClient.PostAsync(PostEndpoint, payload, Token);

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

        Utils.Utils.ValidarStatusCodeNegativo(response,
            "Validar Status code no Endpoint " + PostEndpoint + " No Teste Negativo: " + testCase);
        Utils.Utils.ValidarTextoNoJson(response, textoEsperado, $"Validar Se na Resposta retornou '{textoEsperado}' ");

    }




}
