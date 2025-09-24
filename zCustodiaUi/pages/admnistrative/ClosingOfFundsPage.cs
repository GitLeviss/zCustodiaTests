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

        public ClosingOfFundsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task CloseFund(string fund)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();

            //await util.Click(el.SearchBar, $"Click on Search bar To Find {fund}");
            await util.Write(el.SearchBar, fund, $"Write on Search bar To Find {fund}");
            await Task.Delay(2000);
            await util.Click(el.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await util.Click(el.Calendar, "Click on Calendar to expand the days available");
            await util.Click(el.DayValue(tomorrow), "Set Tomorrow day on calendar");
            await util.Click(el.ButtonCloseFund, "Click Button closed fund to confirm the process");
            await util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento", "Validate if message success returner is visible on screen to the user");
            
            
            



        }

    }
}
