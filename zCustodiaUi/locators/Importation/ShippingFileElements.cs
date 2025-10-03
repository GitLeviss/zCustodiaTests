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
        public string ImportButton { get; } = "//span[text()='Importar']";
        public string AttachFileInput { get; } = "//div[@role='button'][@dropzone]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";



    }
}
