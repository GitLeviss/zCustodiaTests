using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaApi.Utils
{
    public class Utils
    {
        public static void ValidarStatusCode(HttpResponseMessage response, string passo)
        {
            try
            {
                Assert.That(response.StatusCode,
                    Is.EqualTo(System.Net.HttpStatusCode.OK).Or.EqualTo(System.Net.HttpStatusCode.Created),
                    $"Falha ao cadastrar usuário. Status retornado: {(int)response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel Validar Status Code na Rota " + passo + ex.Message);
            }
        }
        public static void ValidarStatusCodeNegativo(HttpResponseMessage response, string passo)
        {
            try
            {
                Assert.That(response.StatusCode,
                    Is.EqualTo(System.Net.HttpStatusCode.UnprocessableEntity).Or.EqualTo(System.Net.HttpStatusCode.BadRequest),
                    $"Falha ao cadastrar usuário. Status retornado: {(int)response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel Validar Status Code na Rota " + passo + ex.Message);
            }
        }

        public static void ValidarTextoNoJson(HttpResponseMessage response, string textoEsperado, string passo)
        {
            try
            {
                var content = response.Content.ReadAsStringAsync().Result;

                Assert.That(content,Does.Contain(textoEsperado),
                    $"Falha na validação do corpo da resposta. Texto esperado: '{textoEsperado}' não encontrado. Corpo retornado: {content}");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível validar o corpo da resposta na rota " + passo + ". Erro: " + ex.Message);
            }
        }
    }
}
