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
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.processing;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.processing
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureNUnit]
    [AllureOwner("Levi")]
    [AllureSuite("Processing - Receivables ")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    public class ReceivablesTests :TestBase
    {
        private IPage page;
        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();

        [SetUp]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            util = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Open main menu to extend options");
            await util.Click(mod.ProcessingPage, "Open Receivables module");
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Process_Receivable()
        {
            var receivablesPage = new ReceivablesPage(page);
            await receivablesPage.ProcessReceivablePartial();
        }
        [Test, Order(2)]
        public async Task Should_Process_Receivable_Partial()
        {
            var receivablesPage = new ReceivablesPage(page);
            await receivablesPage.ProcessReceivable();
        }

    }
}
