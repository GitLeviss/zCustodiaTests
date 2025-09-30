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


    }
}
