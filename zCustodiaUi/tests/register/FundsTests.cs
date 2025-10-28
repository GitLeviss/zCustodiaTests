using Allure.Commons;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Threading.Tasks;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.register;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.register
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureNUnit]
    [AllureOwner("Levi")]
    [AllureSuite("Register - Funds")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    public class FundsTests : TestBase
    {
        private IPage page;
        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();
        private readonly FundsElements el = new FundsElements();

        [SetUp]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            util = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Open main menu to extend options");
            await util.Click(mod.RegisterPage, "Open Register module");
            await util.Click(el.FundsPage, "Open Funds page");
        }

        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [Ignore ("Esse teste está em espera para fluxo de exclusão")]
        public async Task Should_Register_a_New_Fund()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.RegisterNewFund();
        }
        [Test, Order(2)]
        public async Task Should_Consult_a_Fund()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.ConsultFund();
        }
        [Test, Order(3)]
        [Ignore("Esse teste está em espera para fluxo de exclusão")]
        public async Task Should_Update_a_Fund()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.UpdateFund();
        }
    }
}



