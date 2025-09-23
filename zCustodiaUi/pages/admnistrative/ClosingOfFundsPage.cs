using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.reports;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.admnistrative
{
    public class ClosingOfFundsPage
    {
        private readonly IPage page;
        Utils util;
        ClosingOfFundsElements el = new ClosingOfFundsElements();
        ChooseFundDateElements choose = new ChooseFundDateElements();
        MyReportsElements reports = new MyReportsElements();
        ModulesElements mod = new ModulesElements();

        public ClosingOfFundsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task CloseFund()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();

            string fund = "Zitec FIDC";

            await util.Click(el.SearchBar, $"Click on Search bar To Find {fund}");
            await util.Write(el.SearchBar, fund, $"Write on Search bar To Find {fund}");
            await Task.Delay(2000);
            await util.Click(el.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await util.Click(el.Calendar, "Click on Calendar to expand the days available");
            await util.Click(el.DayValue(tomorrow), "Set Tomorrow day on calendar");
            await util.Click(el.ButtonCloseFund, "Click Button closed fund to confirm the process");
            await util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento", "Validate if message success returner is visible on screen to the user");
            //Validate generate report
            await util.Click(mod.MainMenu, "Click on main menu");
            await util.Click(mod.ReportsPage, "Click on section reports on main menu");
            await util.Click(reports.MyReportsPage, "Click on My Reports Page to go to page");
            await util.Click(reports.Calendar, "Click on calendar to expand days available");
            await util.Click(reports.DayValue(tomorrow), "set day that want filter");
            await util.Click(reports.SearchBar, $"Click on search bar to search {fund} fund");
            await util.Write(reports.SearchBar, fund, $"filter to {fund}");
            await util.ValidateFundReportGenerated(page, reports.TableReports("1"), $"{fund}", "CAPA_ESTOQUE", "Validate if report generate \"CAPA_ESTOQUE\" is present on the table");
            await util.ValidateFundReportGenerated(page, reports.TableReports("2"), $"{fund}", "LIQUIDADOS_BAIXADOS", "Validate if report generate \"LIQUIDADOS_BAIXADOS\" is present on the table");
            await util.ValidateFundReportGenerated(page, reports.TableReports("3"), $"{fund}", "AQUISICAO", "Validate if report generate \"AQUISICAO\" is present on the table");
            await util.ValidateFundReportGenerated(page, reports.TableReports("4"), $"{fund}", "ESTOQUE_COMPLETOV2", "Validate if report generate \"ESTOQUE_COMPLETOV2\" is present on the table");
            await util.ValidateFundReportGenerated(page, reports.TableReports("5"), $"{fund}", "ESTOQUE_COMPLETO", "Validate if report generate \"ESTOQUE_COMPLETO\" is present on the table");
            await util.Click(mod.MainMenu, "Click on main menu");
            //await utils.Click(mod.AdmnistrativePage, "Click on Administrative Page to navigate on options page");
            await util.Click("(//mat-icon[text()=' keyboard_arrow_down '])[3]", "Click on Administrative Page to navigate on options page");
            //await util.Click(choose.ChooseFundDatePage, "Click on Choose Fund Date Page to navigate on page");
            await util.Click("//a[text()=' Alteração Data do Fundo ']", "Click on Choose fund date Page to navigate on page");
            await util.Click(choose.SearchBar, "Click on Search bar");
            await util.Write(choose.SearchBar, fund, $"Write on Search bar To Find {fund}");
            await Task.Delay(2000);
            await util.Click(choose.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await util.Click(choose.Calendar, "Click on Calendar to extend to show days available");
            await util.Click(choose.DayValue(today), "set day that want filter on choose day to back fund");
            await util.Click(choose.ChooseButton, "Click on choose button to confirm back date fund");
            await util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento", "Validate if message success returner is visible on screen to the user to back date of fund");

            



        }

    }
}
