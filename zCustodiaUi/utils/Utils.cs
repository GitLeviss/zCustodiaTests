using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public async Task ForceElementVisibleAsync(string locator, string step)
        {
            try
            {
                var element = page.Locator(locator);

                // Wait for element to be attached to DOM
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Attached,
                    Timeout = 60000
                });

                // Wait for element to be visible (not hidden by CSS)
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000
                });
                // Verify element is in viewport
                if (!await element.IsVisibleAsync())
                {
                    throw new Exception("Element is not visible after scrolling");
                }
                else
                {
                    await element.ClickAsync();
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Could not make element visible: {locator} in step: {step}. Error: {ex.Message}");
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

        public async Task ValidateDownloadAndLength(IPage page, string locatorClickDownload, string step, string downloadsDir = null)
        {
            try
            {
                downloadsDir ??= Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"
                );

                // Dispara o download e captura o objeto
                var download = await page.RunAndWaitForDownloadAsync(async () =>
                {
                    var element = page.Locator(locatorClickDownload);
                    await element.WaitForAsync();
                    await element.ClickAsync();
                });

                // Nome real sugerido pelo navegador
                var fileName = download.SuggestedFilename;
                var finalPath = Path.Combine(downloadsDir, fileName);

                // Remove arquivo pré-existente com o mesmo nome
                if (File.Exists(finalPath))
                    File.Delete(finalPath);

                // Salva no destino final
                await download.SaveAsAsync(finalPath);

                // Validações
                Assert.That(File.Exists(finalPath), $"❌ Arquivo '{fileName}' não foi salvo.");
                var info = new FileInfo(finalPath);
                Assert.That(info.Length, Is.GreaterThan(0), $"❌ Arquivo '{fileName}' está vazio (0 bytes).");

                Console.WriteLine($"✅ Download ok: '{fileName}' | {info.Length} bytes.");

                // (Opcional) limpar depois
                // File.Delete(finalPath);
                // Console.WriteLine("ℹ️ Arquivo excluído após validação.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"❌ Erro ao validar download no passo '{step}': {ex.Message}");
            }
        }

        public async Task ScrollToElement(string locator, string step)
        {
            try
            {
                var element = page.Locator(locator);
                await element.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await element.ScrollIntoViewIfNeededAsync();
                // Wait a bit to ensure scroll position is maintained
                await Task.Delay(500);
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to scroll on step: " + step);
            }
        }

        public async Task ScrollToElementAndMaintainPosition(string locator, string step)
        {
            try
            {
                var element = page.Locator(locator);
                await element.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await element.ScrollIntoViewIfNeededAsync();
                
                // Wait for any JavaScript to settle
                await Task.Delay(1000);
                
                // Check if element is still visible, if not scroll again
                var isVisible = await element.IsVisibleAsync();
                if (!isVisible)
                {
                    await element.ScrollIntoViewIfNeededAsync();
                    await Task.Delay(500);
                }
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to scroll and maintain position on step: " + step);
            }
        }

        public async Task ClickMatTabAsync(string tabLocator, string step)
        {
            try
            {
                var tab = page.Locator(tabLocator);
                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Attached,
                    Timeout = 60000
                });

                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000
                });
                await page.WaitForTimeoutAsync(500); 
                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000
                });

                await tab.ClickAsync(new LocatorClickOptions
                {
                    Timeout = 60000,
                    Force = true,  // Bypass actionability checks
                    Position = new Position { X = 10, Y = 10 }  // Click near top-left corner
                });
                await tab.ClickAsync();
                // 5. Wait for Angular to process the click
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await page.WaitForTimeoutAsync(300); // Additional stability wait
            }
            catch (Exception ex)
            {
                throw new PlaywrightException(
                    $"Failed to click Angular Material tab: {tabLocator} in step: {step}. " +
                    $"Error: {ex.Message}. " +
                    "Try checking if the tab is inside a collapsed container or requires specific interaction."
                );
            }
        }

        public async Task DisableDuplicataOptionAsync(string step)
        {
            try
            {
                await page.EvalOnSelectorAsync(
                    "mat-option[ng-reflect-value='Duplicata']",
                    "el => el.disabled = true");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Failed to disable Duplicata option in step {step}: {ex.Message}");
            }
        }





    }
}
