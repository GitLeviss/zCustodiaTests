using zCustodiaApi.ApiObjects;
using NUnit.Framework;

namespace zCustodiaApi.Tests;

public class CedentesTests
{
    private CedentesApi cedentesApi = null!;

    [SetUp]
    public async Task Setup()
    {            
        cedentesApi = new CedentesApi();   
    }

    [Test]
    public async Task DeveCadastrarNovoCedenteComSucesso()
    {
        await cedentesApi.CadastrarCedenteComSucesso("Anderson Barbosa", "Teste@1234");
    }
    [Test]
    public async Task DeveConsultarCedenteComSucesso()
    {
        await cedentesApi.ConsultarCedenteComSucesso("1", "CT02 - Consultar Cedente Com sucesso");
    }
}
