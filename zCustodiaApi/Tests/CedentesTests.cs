using NUnit.Framework;
using zCustodiaApi.ApiObjects;

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
    public async Task Deve_Atualizar_Cedente_Com_Sucesso()
    {
        await cedentesApi.AtualizarCedenteComSucesso("CT-02 - Deve Atualizar Cedente Com Sucesso");
    }
    [Test, Order(3)]
    public async Task Deve_Consultar_Cedente_Com_Sucesso()
    {
        await cedentesApi.ConsultarCedenteComSucesso("CT03 - Deve Consultar Cedente Com sucesso");
    }
    [Test, Order(4)]
    public async Task Deve_Deletar_Cedente_Com_Sucesso()
    {
        await cedentesApi.DeletarCedenteComSucesso("CT04 - Deve Deletar Cedente Com sucesso");
    }
}
