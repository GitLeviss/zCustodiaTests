using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators
{
    public class GenericElements
    {
        public string ButtonNew { get; } = "//span[text()='Novo']";
        public string Filter { get; } = "#z-select-filter-input";
        public string DayValue(string day) => $"//td[@role='gridcell']//button//span[text()=' {day} ']";
        public string TabAllForms(string form) => $"//span[text()=' {form} ']";
        public string RightArrow { get; } = "(//div[@class='mat-mdc-tab-header-pagination-chevron'])[2]";
        public string ReceiveTypeOption(string option) => $"//span[text()=' {option} ']";
        public string Locator(string LocatorName) => $"//mat-label[text()='{LocatorName}']";
        public string AddButton { get; } = "//span[text()='Adicionar']";
        public string SuccessMessage { get; } = "//div[contains(text(),'sucesso')]";
        public string SaveButton { get; } = "//span[text()='Salvar']";
        public string FilterButton { get; } = "//button//mat-icon[text()=' filter_alt ']";
        public string EditButton { get; } = "(//mat-icon[text()=' edit_note '])[1]";



    }
}
