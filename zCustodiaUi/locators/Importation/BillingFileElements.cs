using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.Importation
{
    public class BillingFileElements
    {
        public string BillingFilePage { get; } = "//span[text()='Retorno Cobrança']";
        public string ProcessButton { get; } = "//span[text()='Processar']";
        public string Dropzone { get; } = "//div[@dropzone]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string IdPositionOnTheTable { get; } = "(//tr//td)[2]//app-table-cell//div//span";
        public string NameFilePositionOnTheTable { get; } = "(//tr//td)[4]//app-table-cell//div//span";
        public string NoneValue { get; } = "//h2[text()=' Nenhum Valor Encontrado ']";
        public string Table { get; } = "//table//tbody";
        public string DeleteButton(string fileName) => $"//span[normalize-space(text())='{fileName}']/ancestor::tr//button[.//mat-icon[normalize-space(text())='delete']]";
    }
}
