using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;
using static System.Net.Mime.MediaTypeNames;


namespace zCustodiaUi.utils
{
    public class Utils
    {
        private readonly IPage page;
        public Utils(IPage page)
        {
            this.page = page;
        }

        public async Task Write(string locator, string text, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync();
                await elemento.FillAsync(text);
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to write on step: " + step);
            }
        }

        public async Task Click(string locator, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await elemento.ClickAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to click on step: " + step);
            }
        }

        public async Task ClickOnTheSelector(string locator, string option, string step)
        {
            try
            {
                await page.Locator(locator).SelectOptionAsync(new[] { option });
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + "to select on step: " + step);
            }
        }


        public async Task ValidateUrl(string expectedUrl, string step)
        {
            try
            {
                await page.WaitForURLAsync(expectedUrl);
                if (expectedUrl == "https://custodia.idsf.com.br/home/dashboard")
                {
                    await Expect(page).ToHaveURLAsync(expectedUrl);
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate expected Url: '{expectedUrl}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        public async Task ValidateReturnedMessageIsVisible(string locator, string step)
        {
            try
            {
                await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Visible
                });
                await Expect(page.Locator(locator)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element:'{locator}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        public async Task ValidateElementPresentOnTheTable(IPage page, string locatorTable, string expectedText, string step)
        {
            try
            {
                await page.WaitForSelectorAsync(locatorTable, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Visible
                });

                var locator = page.Locator(locatorTable);
                int count = await locator.CountAsync();

                bool textFound = false;

                for (int i = 0; i < count; i++)
                {
                    var text = await locator.Nth(i).InnerTextAsync();

                    if (!string.IsNullOrWhiteSpace(text) && text.Contains(expectedText, StringComparison.OrdinalIgnoreCase))
                    {
                        textFound = true;
                        Console.WriteLine($" Text found: {text}");
                        break;
                    }
                }

                Assert.That(textFound, Is.True, $" The text '{expectedText}' don´t found on the table: {locatorTable}");
            }
            catch (TimeoutException)
            {
                throw new Exception($" time out to wait the table is visible on step: {step}");
            }
            catch (Exception ex)
            {
                throw new Exception($" Error to verify the text'{expectedText}' on the table on step: {step}.");
            }
        }

        public async Task ValidateFundReportGenerated(IPage page, string lineSelector, string expectedFundo, string expectedRelatorio, string step)
        {
            try
            {
                bool textsFound;
                string fundPosition = lineSelector + "//td[2]//app-table-cell//div//span";
                string reportPosition = lineSelector + "//td[4]//app-table-cell//div//span";

                string fundText = (await page.Locator(fundPosition).InnerTextAsync()).Trim();
                string reportText = (await page.Locator(reportPosition).InnerTextAsync()).Trim();

                Assert.That(fundText, Does.Contain(expectedFundo).IgnoreCase);
                Assert.That(reportText, Does.Contain(expectedRelatorio).IgnoreCase);
            }
            catch
            {
                throw new Exception($"Don´t possible validate generation report on step: {step}.");
            }
        }

        public async Task ValidateTextIsVisibleOnScreen(string expectedText, string step)
        {
            try
            {
                await page.GetByText(expectedText)
                  .WaitForAsync(new LocatorWaitForOptions
                  {
                      State = WaitForSelectorState.Visible
                  });
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element: '{expectedText}' on step: '{step}'.");






            }
        }
    }
}
