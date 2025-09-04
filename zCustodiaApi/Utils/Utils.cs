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

        public static void ValidarResponseBody(HttpResponseMessage response, string passo)
        {
            try
            {
            
            }
            catch (Exception ex)
            {


            }
        }

    }
}
