using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.locators.modules;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.admnistrative
{
    public class ChooseFundDatePage
    {
        private IPage page;
        Utils util;
        ChooseFundDateElements choose = new ChooseFundDateElements();
        ModulesElements mod = new ModulesElements();


        public ChooseFundDatePage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task ChooseFundDate(string fund)
        {
            var today = DateTime.Now.Day.ToString();

            await Task.Delay(3500);
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
