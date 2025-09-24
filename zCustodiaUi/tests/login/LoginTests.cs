using Allure.Commons;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.pages;
using zCustodiaUi.pages.login;
using zCustodiaUi.runner;

namespace zCustodiaUi.tests.login
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureNUnit]
    [AllureOwner("Levi")]
    [AllureSuite("Login")]
    [AllureSeverity(SeverityLevel.critical)]    
    [Category("Critícity: Critical")]
    [Category("Regression Tests")]
    public class LoginTests : TestBase
    {
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Do_Login_With_Valid_Credentials()
        {
            var login = new LoginPage(page);
            await login.DoLogin();
        }
        [Test, Order(2)]
        public async Task Do_Not_Should_Do_Login_With_Invalid_Email()
        {
            var login = new LoginPage(page);
            await login.NegativeLogin("invalid email");
        }
        [Test, Order(3)]
        public async Task Do_Not_Should_Do_Login_With_Invalid_Password()
        {
            var login = new LoginPage(page);
            await login.NegativeLogin("invalid password");
        }

    }
}
