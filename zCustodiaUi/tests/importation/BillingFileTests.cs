using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators.modules;
using zCustodiaUi.pages.importation;
using zCustodiaUi.pages.login;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.importation
{
    public class BillingFileTests : TestBase
    {
        private IPage page;
        ModulesElements mod = new ModulesElements();

        Utils util;
        [SetUp]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            util = new Utils(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Click on Main menu to extend page Options");
            await util.Click(mod.ImportationPage, "Click on Importation Page to navigate on options page");
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }
        [Test, Order(1)]
        public async Task Should_Import_a_New_Billing_File()
        {
            var billingFile = new BillingFilePage(page);
            await billingFile.SendBillingFile();
        }
    }
}
