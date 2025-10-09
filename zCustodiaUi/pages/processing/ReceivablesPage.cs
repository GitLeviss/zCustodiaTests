using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators;
using zCustodiaUi.locators.processing;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.processing
{
    public class ReceivablesPage
    {
        private readonly IPage page;
        Utils util;
        ReceivablesElements el = new ReceivablesElements();
        GenericElements gen = new GenericElements();


        public ReceivablesPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public static string GetPath()
        {
            ConfigurationManager config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            string path = config["Paths:Arquivo"].ToString();
            return path;
        }

        public async Task ProcessReceivablePartial()
        {
            await util.Click(el.ReceivablesPage, "Click on Receivables page to navigate on the page");
            await Task.Delay(300);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await util.Write(gen.Filter,"Zitec FIDC", "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption("Zitec FIDC"), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await util.Write(gen.LocatorMatLabel("Seu Número"), "9610646761377766170078081", "Write on your number field to Filter per your number");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await util.Click(el.SecondCheckBox, "Click on CheckBox");
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, "LIQUIDAÇÃO PARCIAL", "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption("LIQUIDAÇÃO PARCIAL"), "Click on liquidation partial to select liquidation partial option");
            await util.Write(gen.LocatorMatLabel("Valor Liquidação"), "10", "Write on value of liquidation ");
            await page.Keyboard.PressAsync("Space");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user");
            await Task.Delay(300);
            await util.ValidateTextIsVisibleInElement(el.StatusPositionOnTheTable, "Ativo", "Validate if status of Receivable is Ativo after did processing");
            // Do Delete Last movement


        }
        public async Task ProcessReceivable()
        {
            await util.Click(el.ReceivablesPage, "Click on Receivables page to navigate on the page");
            await Task.Delay(300);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await util.Write(gen.Filter,"Zitec FIDC", "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption("Zitec FIDC"), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await util.Write(gen.LocatorMatLabel("Seu Número"), "5549079699832046128068212", "Write on your number field to Filter per your number");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await util.Click(el.SecondCheckBox, "Click on CheckBox");
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, "BAIXA", "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption("BAIXA"), "Click on low to select low option");
            await util.Write(gen.LocatorMatLabel("Valor Liquidação"), "100000", "Write on value of liquidation ");
            await page.Keyboard.PressAsync("Space");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user");
            await Task.Delay(300);
            await util.ValidateTextIsVisibleInElement(el.StatusPositionOnTheTable, "Inativo", "Validate if status of Receivable is Ativo after did processing");
            // Do Delete Last movement


        }
    }
}
