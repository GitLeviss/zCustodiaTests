using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaApi.models.requests.cedentes
{



    public class CadastrarCedentesReq
    {
        public static Dictionary<string, object> CedenteValido(
        string nome = "CEDENTE CT-01 - Deve Cadastrar Cedente Com Sucesso",
        Action<Dictionary<string, object>>? mutate = null)
        {
            var d = new Dictionary<string, object>
            {
                ["fundo"] = new Dictionary<string, object>
            {
                { "id", 9991 },
                { "nome", null },
                { "cnpj", null },
                { "data", null }
            },

                ["nome"] = nome,
                ["tipoPessoa"] = 1,
                ["cnpjcpf"] = "38932498008",
                ["tipoInscricaoEstadualIsento"] = false,
                ["inscricaoEstadual"] = "123",
                ["inscricaoMunicipal"] = "123",
                ["ramoAtividade"] = 4,
                ["porte"] = 10,
                ["email"] = "teste@gmail.com",
                ["tipoSociedade"] = 15,
                ["classificacaoRisco"] = 1,
                ["inicioRelacionamento"] = "2023-06-05T00:00:00",
                ["terminoRelacionamento"] = "2023-06-06T00:00:00",
                ["faturamentoAnual"] = 3000,
                ["autorizacao"] = true,

                ["endereco"] = "Rua Pia",
                ["numero"] = "422",
                ["complemento"] = "casa",
                ["cep"] = "05335059",
                ["bairro"] = "Jaguare",
                ["cidade"] = "Sao Paulo",
                ["uf"] = "SP",

                ["telefoneDDD"] = "11989999518",
                ["faxDDD"] = "11989999518",
                ["conglomeradoEconomico"] = "teste",
                ["numMinAssinaturasAprovacao"] = 1,
                ["limiteCredito"] = 10000,
                ["cedenteBloqueado"] = false,
                ["recuperacaoJudicial"] = true,
                ["tipoControleCedente"] = "1",
                ["isCoobrigacao"] = true,
                ["tipoCoobrigacao"] = "A",
                ["origemCadastro"] = "Custodia",
                ["origemAlteracao"] = "web-zitec",
                ["dataCadastro"] = "2021-03-12T00:00:00",
                ["alteradoPor"] = "idctvm_api",
                ["dataUltimaAlteracao"] = "2025-09-05T11:58:05.579Z",
                ["ativaRepresentanteConsultoria"] = false,
                ["operaSacadoSemRisco"] = false,
                ["permiteContaCorrenteSemDados"] = true,
                ["instituicaoFinanceira"] = true,
                ["codigoCNAE"] = null,
                ["dividaUniao"] = true,
                ["tipoChavePix"] = "3",
                ["chavePix"] = "a@email.com",

                ["dadosBancarios"] = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        ["banco"] = new Dictionary<string, object>
                        {
                            { "idBanco", 137 }
                        },
                        ["id"] = 1,
                        ["numeroAgencia"] = "3322",
                        ["digitoAg"] = "4",
                        ["numeroConta"] = "77665",
                        ["digitoConta"] = "6",
                        ["descricao"] = "BANCO CEDENTE",
                        ["contaAtivado"] = true,
                        ["isPadrao"] = true
                    }
                },

                ["representantes"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "id", 2 },
                    { "assina", true },
                    { "assinaEndosso", true },
                    { "assinaTermoCessao", true },
                    { "cpfCnpj", "32084289874" },
                    { "email", "vk@zitec.ai" },
                    { "emiteDuplicata", true },
                    { "nomeRepresentante", "Vitor Kenzo" },
                    { "numeroTelefone", "11111111111" },
                    { "assinaIsoladamente", false }
                },
                new Dictionary<string, object>
                {
                    { "id", 117528686 },
                    { "assina", false },
                    { "assinaEndosso", false },
                    { "assinaTermoCessao", false },
                    { "cpfCnpj", "42400541841" },
                    { "email", "jkevinbr@gmail.com" },
                    { "emiteDuplicata", false },
                    { "nomeRepresentante", "JEAN KEVIN BASTOS SANTOS" },
                    { "numeroTelefone", "11977649638" },
                    { "assinaIsoladamente", false }
                }
            },

                ["avalistas"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "nome", "Leticia de Abreu Rudeli" },
                    { "email", "leticiarudeli11@gmail.com" },
                    { "cpfCnpj", "39973705831" }
                }
            },

                ["partesRelacionadas"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "nome", "TESTE FROMTIS" },
                    { "cpfCnpj", "78715761000117" }
                }
            }
            };

            mutate?.Invoke(d);

            return d;
        }
    }



}








