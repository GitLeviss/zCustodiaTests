﻿using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.runner
{
    public class testBase
    {
        private IPlaywright? playwright;
        private IBrowser? browser;
        private IBrowserContext? context;

        protected async Task<IPage> OpenBrowserAsync()
        {

            playwright = await Playwright.CreateAsync();

            // Detecta CI (Azure DevOps define TF_BUILD=true)
            var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"))
                       || string.Equals(Environment.GetEnvironmentVariable("TF_BUILD"), "True", StringComparison.OrdinalIgnoreCase);

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = isCi, // Headless no CI, pode ser false local
                Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
            };

            browser = await playwright.Chromium.LaunchAsync(launchOptions);
            context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var linkCustodia = config["Links:Custodia"];
            await page.GotoAsync(linkCustodia);
            return page;
        }

        protected async Task CloseBrowserAsync()
        {
            if (context != null)
                await context.CloseAsync();
            if (browser != null)
                await browser.CloseAsync();
            playwright?.Dispose();
        }


    }


}
}
