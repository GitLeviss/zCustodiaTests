using NUnit.Framework;
using zCustodiaApi.ApiObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace zCustodiaApi.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("Suíte: APICedentes")]
[Category("Criticidade: Crítica")]
[Category("Regressivos")]
public class CedentesTests
{
    private CedentesApi cedentesApi = new CedentesApi();

    [Test, Order(1)]
    public async Task Deve_Cadastrar_Novo_Cedente_Com_Sucesso()
    {
        await cedentesApi.CadastrarCedenteComSucesso("CT-01 - Deve Cadastrar Cedente Com Sucesso");
    }
    [Test, Order(2)]
    public async Task Nao_Deve_Cadastrar_Cedente_Ja_Cadastrado()
    {
        await cedentesApi.CadastrarCedenteJaCadastrado("CT-02 - Deve Cadastrar Cedente Com Sucesso", "CNPJ já cadastrado para esse Fundo");
    }
    [Test, Order(3)]
    public async Task Deve_Atualizar_Cedente_Com_Sucesso()
    {
        await cedentesApi.AtualizarCedenteComSucesso("CT-03 - Deve Atualizar Cedente Com Sucesso");
    }
    [Test, Order(4)]
    public async Task Deve_Consultar_Cedente_Com_Sucesso()
    {
        await cedentesApi.ConsultarCedenteComSucesso("CT04 - Deve Consultar Cedente Com sucesso");
    }
    [Test, Order(5)]
    public async Task Deve_Deletar_Cedente_Com_Sucesso()
    {
        await cedentesApi.DeletarCedenteComSucesso("CT05 - Deve Deletar Cedente Com sucesso");
    }
    [Test, Order(6)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_Nome_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT06 - Nao Deve Cadastrar Cedente Com Nome em Branco","nome","", "Nome do Cedente é obrigatório");
    }
    [Test, Order(7)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoPessoa_Null()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT07 - Nao Deve Cadastrar Cedente Com TipoPessoa Null", "tipoPessoa", null, "Error converting value {null} to type 'System.Int16'. Path 'tipoPessoa'");
    }
    [Test, Order(8)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_cnpjcpf_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT08 - Nao Deve Cadastrar Cedente Com cnpjcpf em Branco", "cnpjcpf", "", "Um CPF ou CNPJ para o Cedente é obrigatório");
    }
    [Test, Order(9)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_NumMinAssinatura_0()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT09 - Nao Deve Cadastrar Cedente Com NumMinAssinatura 0", "numMinAssinaturasAprovacao", 0, "O número mínimo de assinaturas para aprovação deve estar entre 1 e 999.");
    }
    [Test, Order(10)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_NumMinAssinatura_1000()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT10 - Nao Deve Cadastrar Cedente Com NumMinAssinatura 1000", "numMinAssinaturasAprovacao", 1000, "O número mínimo de assinaturas para aprovação deve estar entre 1 e 999.");
    }
    [Test, Order(11)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_Email_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT11 - Nao Deve Cadastrar Cedente Com Email em Branco", "email", "", "E-mail do Cedente é obrigatório");
    }
    [Test, Order(12)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_Email_invalido()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT12 - Nao Deve Cadastrar Cedente Com Email invalido", "email", "testegmail.com", "E-mail do Cedente inválido");
    }
    [Test, Order(13)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_ramoAtividade_0()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT13 - Nao Deve Cadastrar Cedente Com ramoAtividade 0", "ramoAtividade", 0, "Id do Ramo de Atividade do Cedente é obrigatório");
    }
    [Test, Order(14)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_ramoAtividade_999999()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT14 - Nao Deve Cadastrar Cedente Com ramoAtividade 999999", "ramoAtividade", 999999, "Erro ao criar o cedente.");
    }
    [Test, Order(15)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoSociedade_0()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT15 - Nao Deve Cadastrar Cedente Com TipoSociedade 999999", "tipoSociedade", 0, "Id do Tipo de Sociedade do Cedente é obrigatório");
    }
    [Test, Order(16)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoSociedade_999999()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT16 - Nao Deve Cadastrar Cedente Com TipoSociedade 999999", "tipoSociedade", 999999, "Tipo de Sociedade inválido");
    }
    [Test, Order(17)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoSociedade_1()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT17 - Nao Deve Cadastrar Cedente Com TipoSociedade 1", "tipoSociedade", 1, "Tipo de Sociedade inválido");
    }
    [Test, Order(18)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_PorteCedente_0()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT18 - Nao Deve Cadastrar Cedente Com PorteCedente 0", "porte", 0, "Porte do Cedente é obrigatório");
    }
    [Test, Order(19)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_PorteCedente_999999()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT19 - Nao Deve Cadastrar Cedente Com PorteCedente 999999", "porte", 999999, "Erro ao criar o cedente.");
    }
    [Test, Order(20)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_ClassficacaoRisco_null()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT20 - Nao Deve Cadastrar Cedente Com ClassficacaoRisco null", "classificacaoRisco", null, "Error converting value {null} to type 'System.Int16'. Path 'classificacaoRisco'");
    }
    [Test, Order(21)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_ClassficacaoRisco_0()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT21 - Nao Deve Cadastrar Cedente Com ClassficacaoRisco 0", "classificacaoRisco", 0, "Classificação de Risco do Cedente é obrigatória");
    }
    [Test, Order(22)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_ClassficacaoRisco_999999()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT22 - Nao Deve Cadastrar Cedente Com ClassficacaoRisco 999999", "classificacaoRisco", 999999, "Error converting value 999999 to type 'System.Int16'. Path 'classificacaoRisco'");
    }
    [Test, Order(23)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_FaturamentoAnual_null()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT23 - Nao Deve Cadastrar Cedente Com FaturamentoAnual null", "faturamentoAnual", null, "Error converting value {null} to type 'System.Decimal'. Path 'faturamentoAnual'");
    }
    [Test, Order(24)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TelefoneDDD_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT24 - Nao Deve Cadastrar Cedente Com TelefoneDDD em Branco", "telefoneDDD", "", "Telefone do Cedente é obrigatório");
    }
    [Test, Order(25)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_tipoCoobrigacao_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT25 - Nao Deve Cadastrar Cedente Com tipoCoobrigacao em Branco", "tipoCoobrigacao", "", "Tipo de Coobrigação do Cedente é obrigatório se há coobrigação");
    }
    [Test, Order(26)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_alteradoPor_em_Branco()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT26 - Nao Deve Cadastrar Cedente Com alteradoPor em Branco", "alteradoPor", "", "AlteradoPor do Cedente é obrigatório");
    }
    [Test, Order(27)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_dataUltimaAlteracao_null()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT27 - Nao Deve Cadastrar Cedente Com dataUltimaAlteracao null", "dataUltimaAlteracao", null, "Error converting value {null} to type 'System.DateTime'. Path 'dataUltimaAlteracao'");
    }
    [Test, Order(28)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoChavePix_1_10Chars()
    {
        await cedentesApi.CadastrarCedenteNegativoPix("CT28 - Nao Deve Cadastrar Cedente Com TipoChavePix 1 10Chars",
            "1",
            "1234567890",
            "Formato da chave PIX não condiz com o Tipo da Chave");
    }
    [Test, Order(29)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoChavePix_1_12Chars()
    {
        await cedentesApi.CadastrarCedenteNegativoPix("CT29 - Nao Deve Cadastrar Cedente Com TipoChavePix 1 12Chars",
            "1",
            "123456789012",
            "Formato da chave PIX não condiz com o Tipo da Chave");
    }
    [Test, Order(30)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoChavePix_4_31Chars()
    {
        await cedentesApi.CadastrarCedenteNegativoPix("CT30 - Nao Deve Cadastrar Cedente Com TipoChavePix 4 31Chars",
            "4",
            "1234567891123456789112345678911",
            "Formato da chave PIX não condiz com o Tipo da Chave");
    }
    [Test, Order(31)]
    public async Task Nao_Deve_Cadastrar_Cedente_Com_TipoChavePix_4_33Chars()
    {
        await cedentesApi.CadastrarCedenteNegativoPix("CT31 - Nao Deve Cadastrar Cedente Com TipoChavePix 4 33Chars",
            "4",
            "123456789112345678911234567891123",
            "Formato da chave PIX não condiz com o Tipo da Chave");
    }
    [Test, Order(32)]
    public async Task Nao_Deve_Cadastrar_Cedente_Sem_ContaBancaria()
    {
        await cedentesApi.CadastrarCedenteNegativo("CT32 - Nao Deve Cadastrar Cedente Com DadosBancarios em branco", "dadosBancarios", "", "The DadosBancarios field is required.");
    }
    [Test, Order(33)]
    [Ignore ("Este Teste Esta em manutenção!")]
    public async Task Nao_Deve_Consultar_Cedente_Pelo_ID_Inexistente()
    {
        await cedentesApi.ConsultarCedenteNegativo("CT33 - Nao Deve Consultar Cedente Com ID Inexitente", 101010101, "");
    }
    [Test, Order(34)]
    [Ignore ("Este Teste Esta em manutenção!")]
    public async Task Nao_Deve_Consultar_Cedente_Pelo_ID_0()
    {
        await cedentesApi.ConsultarCedenteNegativo("CT34 - Nao Deve Consultar Cedente Com ID Inexitente", 0, "");
    }
    [Test, Order(35)]
    [Ignore ("Este Teste Esta em manutenção!")]
    public async Task Nao_Deve_Consultar_Cedente_Pelo_ID_menos1()
    {
        await cedentesApi.ConsultarCedenteNegativo("CT35 - Nao Deve Consultar Cedente Com ID Inexitente", -1, "");
    }
    [Test, Order(36)]
    [Ignore ("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Id_menos1()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT36 - Não Deve Atualizar Cedente Com Com Id menos1", "id", -1, "Nome do Cedente é obrigatório");
    }
    [Test, Order(37)]
    [Ignore ("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Id_0()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT37 - Não Deve Atualizar Cedente Com Id 0", "id", 0, "Nome do Cedente é obrigatório");
    }
    [Test, Order(38)]
    [Ignore ("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Id_01010101()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT38 - Não Deve Atualizar Cedente Com Id 01010101", "id", 01010101, "Nome do Cedente é obrigatório");
    }
    [Test, Order(39)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Nome_Em_Branco()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT39 - Não Deve Atualizar Cedente Com Nome Em Branco", "nome", "", "Nome do Cedente é obrigatório");
    }
    [Test, Order(40)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Tipo_Pessoa_null()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT40 - Não Deve Atualizar Cedente Com Tipo Pessoa null", "TipoPessoa", null, "Error converting value {null} to type 'System.Int16'. Path 'TipoPessoa'");
    }
    [Test, Order(41)]
    [Ignore ("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Pelo_cpfCnpj()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT41 - Não Deve Atualizar Cedente Pelo cpfCnpj", "cpfCnpj", "40956114806", "Edição do CPF/CNPJ não é permitida");
    }
    [Test, Order(42)]
    [Ignore("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Com_NumMinAssinaturasAprovacao_0()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT42 - Não Deve Atualizar Cedente Com NumMinAssinaturasAprovacao 0", "NumMinAssinaturasAprovacao", 0, "O número mínimo de assinaturas para aprovação deve estar entre 1 e 999.");
    }
    [Test, Order(43)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_NumMinAssinaturasAprovacao_1000()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT43 - Não Deve Atualizar Cedente Com NumMinAssinaturasAprovacao 1000", "NumMinAssinaturasAprovacao", 1000, "O número mínimo de assinaturas para aprovação deve estar entre 1 e 999.");
    }
    [Test, Order(44)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Email_Invalido()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT44 - Não Deve Atualizar Cedente Com Email Invalido", "email", "testeemail.com", "E-mail do Cedente inválido");
    }
    [Test, Order(45)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_IdFundo_0()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT45 - Não Deve Atualizar Cedente Com IdFundo 0", "fundo", "" , "The Fundo field is required.");
    }
    [Test, Order(46)]
    [Ignore ("Este teste esta em manutenção!")]
    public async Task Nao_Deve_Atualizar_Cedente_Com_RamoAtividade_Inexistente()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT46 - Não Deve Atualizar Cedente Com RamoAtividade Inexistente", "ramoAtividade", 12342 , "Erro ao atualizar o cedente: The UPDATE statement conflicted with the FOREIGN KEY constraint");
    }
    [Test, Order(47)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_RamoAtividade_0()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT47 - Não Deve Atualizar Cedente Com RamoAtividade 0", "ramoAtividade", 0 , "Id do Ramo de Atividade do Cedente é obrigatório");
    }
    [Test, Order(48)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_RamoAtividade_null()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT48 - Não Deve Atualizar Cedente Com RamoAtividade null", "ramoAtividade", null , "Error converting value {null} to type 'System.Int32'. Path 'ramoAtividade'");
    }
    [Test, Order(49)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_TipoSociedade__Nao_Permitido()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT49 - Não Deve Atualizar Cedente Com RamoAtividade null", "TipoSociedade", 115 , "Tipo de Sociedade inexistente | Tipo de Sociedade inválido");
    }
    [Test, Order(50)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_TipoSociedade_0()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT50 - Não Deve Atualizar Cedente Com RamoAtividade 0", "TipoSociedade", 0 , "Id do Tipo de Sociedade do Cedente é obrigatório");
    }
    [Test, Order(51)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_Porte_null()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT51 - Não Deve Atualizar Cedente Com Porte null", "porte", null , "Error converting value {null} to type 'System.Int32'. Path 'porte'");
    }
    [Test, Order(52)]
    public async Task Nao_Deve_Atualizar_Cedente_Com_isCoobrigacao_true_Sem_Tipo_Coobrigacao()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT52 - Não Deve Atualizar Cedente Com isCoobrigacao true com Tipo Coobrigacao 0", "tipoCoobrigacao", "" , "Tipo de Coobrigação do Cedente é obrigatório se há coobrigação");
    }
    [Test, Order(53)]
    public async Task Nao_Deve_Atualizar_Cedente_Sem_Representantes()
    {
        await cedentesApi.AtualizarCedenteNegativo("CT53 - Não Deve Atualizar Cedente Sem Representantes", "representantes", "" , "{\"representantes\":[\"The Representantes field is required.\"]}");
    }

}
