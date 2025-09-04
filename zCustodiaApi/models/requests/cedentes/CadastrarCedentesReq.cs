using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaApi.models.requests.cedentes
{   

        public class CadastrarCedentesReq
        {
            public int id { get; set; }
            public string fundo { get; set; }
            public string nome { get; set; }
            public int tipoPessoa { get; set; }
            public string cnpjcpf { get; set; }
            public bool tipoInscricaoEstadualIsento { get; set; }
            public string inscricaoEstadual { get; set; }
            public string inscricaoMunicipal { get; set; }
            public int ramoAtividade { get; set; }
            public int porte { get; set; }
            public string email { get; set; }
            public int tipoSociedade { get; set; }
            public int classificacaoRisco { get; set; }
            public DateTime inicioRelacionamento { get; set; }
            public DateTime terminoRelacionamento { get; set; }
            public int faturamentoAnual { get; set; }
            public bool autorizacao { get; set; }
            public string endereco { get; set; }
            public string numero { get; set; }
            public string complemento { get; set; }
            public string cep { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string telefoneDDD { get; set; }
            public string faxDDD { get; set; }
            public string conglomeradoEconomico { get; set; }
            public int numMinAssinaturasAprovacao { get; set; }
            public int limiteCredito { get; set; }
            public bool cedenteBloqueado { get; set; }
            public bool recuperacaoJudicial { get; set; }
            public string tipoControleCedente { get; set; }
            public bool isCoobrigacao { get; set; }
            public string tipoCoobrigacao { get; set; }
            public string origemCadastro { get; set; }
            public string origemAlteracao { get; set; }
            public DateTime dataCadastro { get; set; }
            public string alteradoPor { get; set; }
            public DateTime dataUltimaAlteracao { get; set; }
            public bool ativaRepresentanteConsultoria { get; set; }
            public bool operaSacadoSemRisco { get; set; }
            public bool permiteContaCorrenteSemDados { get; set; }
            public bool instituicaoFinanceira { get; set; }
            public int codigoCNAE { get; set; }
            public bool dividaUniao { get; set; }
            public string tipoChavePix { get; set; }
            public string chavePix { get; set; }
            public Dadosbancario[] dadosBancarios { get; set; }
            public Representante[] representantes { get; set; }
            public Avalista[] avalistas { get; set; }
            public Partesrelacionada[] partesRelacionadas { get; set; }
        }

        public class Fundo
        {
            public int id { get; set; }
            public string nome { get; set; }
            public string cnpj { get; set; }
            public DateTime data { get; set; }
        }

        public class Dadosbancario
        {
            public Banco banco { get; set; }
            public int id { get; set; }
            public string numeroAgencia { get; set; }
            public string digitoAg { get; set; }
            public string numeroConta { get; set; }
            public string digitoConta { get; set; }
            public string descricao { get; set; }
            public bool contaAtivado { get; set; }
            public bool isPadrao { get; set; }
        }

        public class Banco
        {
            public int idBanco { get; set; }
            public string nomeBanco { get; set; }
            public string codigoBancario { get; set; }
        }

        public class Representante
        {
            public int id { get; set; }
            public bool assina { get; set; }
            public bool assinaEndosso { get; set; }
            public bool assinaTermoCessao { get; set; }
            public string cpfCnpj { get; set; }
            public string email { get; set; }
            public bool emiteDuplicata { get; set; }
            public string nomeRepresentante { get; set; }
            public string numeroTelefone { get; set; }
            public bool assinaIsoladamente { get; set; }
        }

        public class Avalista
        {
            public string nome { get; set; }
            public string email { get; set; }
            public string cpfCnpj { get; set; }
        }

        public class Partesrelacionada
        {
            public string nome { get; set; }
            public string cpfCnpj { get; set; }
        }


    }

