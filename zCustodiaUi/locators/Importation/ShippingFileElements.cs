using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace zCustodiaUi.locators.Importation
{
    public class ShippingFileElements
    {
        public string ShippingFilePage { get; } = "//span[text()='Arquivo Remessa']";
        public string ProcessButton { get; } = "//span[text()='Processar']";
        public string AttachFileInput { get; } = "#file-input-playwright";
        public string Dropzone { get; } = "//div[@dropzone]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string IdPositionOnTheTable { get; } = "(//tr//td)[2]//app-table-cell//div//span";
        public string NameFilePositionOnTheTable { get; } = "(//tr//td)[4]//app-table-cell//div//span";
        public string ReegistersNumber { get; } = "//span[text()='0']";



    }
}
