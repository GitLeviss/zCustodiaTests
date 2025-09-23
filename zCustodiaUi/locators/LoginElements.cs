using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators
{
    public class LoginElements
    {
        public string EmailField { get; } = "#mat-input-0";
        public string PasswordField { get; } = "#mat-input-1";
        public string SubmitButton { get; } = "//span[text()='Acessar']";
    }
}
