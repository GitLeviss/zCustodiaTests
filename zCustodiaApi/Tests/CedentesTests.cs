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
    public async Task DeveCadastrarNovoCedenteComSucesso()
    {
        await cedentesApi.CadastrarCedenteComSucesso("CT-01 - Deve Cadastrar Cedente Com Sucesso");
    }
    [Test, Order(2)]
    public async Task DeveAtualizarCedenteComSucesso()
    {
        await cedentesApi.AtualizarCedenteComSucesso("CT-02 - Deve Atualizar Cedente Com Sucesso");
    }
    [Test, Order(3)]
    public async Task DeveConsultarCedenteComSucesso()
    {
        await cedentesApi.ConsultarCedenteComSucesso( "CT03 - Consultar Cedente Com sucesso");
    }
}
