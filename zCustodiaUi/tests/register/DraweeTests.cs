using Allure.Commons;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [AllureSuite("Register - Drawee")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    public class DraweeTests : TestBase
    {
        private IPage page;
        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();
        DraweeElements el = new DraweeElements();
        [SetUp]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            util = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Open main menu to extend options");
            await util.Click(mod.RegisterPage, "Open Register module");
            await util.Click(el.DraweePage, "Click on drawee page to visit page");
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [Ignore ("Este teste esta em manutenção")]
        public async Task Should_Register_New_Assignors()
        {
            var drawee = new DraweePage(page);
            await drawee.Register_Drawee();
        }
        


    }
}
