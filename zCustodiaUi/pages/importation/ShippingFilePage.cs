using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators;
using zCustodiaUi.locators.Importation;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.importation
{
    public class ShippingFilePage
    {
        private readonly IPage page;
        Utils util;
        ShippingFileElements el = new ShippingFileElements();
        GenericElements gen = new GenericElements();

        string nameNewFile { get; set; }

        public ShippingFilePage(IPage page)
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


        public async Task SendShippingFile()
        {
            var today = DateTime.Now.Day.ToString();
            string fundName = "Zitec FIDC";
            await util.Click(el.ShippingFilePage, "Click on Shipping File page to navigate on the page");
            await util.Click(el.ImportButton, "Click on Import button to import a new shipping file");            
            await util.Click("(" + gen.Locator("Fundo")+")[2]", "Click on Fund Select to expand a Funds list");
            await util.Write(gen.Filter, fundName, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(fundName), "Click on fund option");
            //await util.Click(gen.DayValue(today), "Set day on calendar");  
            await Task.Delay(150);
            nameNewFile = await util.UpdateDateAndSentFile(GetPath() + "CNABz - Copia.txt", el.AttachFileInput, "Attaching a new shipping file");
        }


    }
}
