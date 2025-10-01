using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class AssignorsPage
    {
        private readonly IPage page;
        private readonly Utils util;
        private readonly GenericElements gen = new GenericElements();
        private readonly AssignorsElements el = new AssignorsElements();
        public AssignorsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task RegisterNewAssignor()
        {
            await util.Click(el.AssignorPage, "Click on assignor page to visit page");
            await util.Click(el.NewAssignorButton, "Click on new assignor button to start register");
            await util.Click(el.FormAssignors, "Click on Form Assignors button to start register");
            await util.Click(el.FundSelect, "Click on fund select");
            await util.Write(gen.Filter,"Zitec FIDC", "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption("Zitec FIDC"), "Click on fund option");
            await util.Write(el.NameInput, "Cedente Teste Zitec", "Insert Name of Assignor to be Registered");
            await util.Write(el.CpjCnpjInput, "12.345.678/0001-90", "Insert CNPJ of Assignor to be Registered");
            await util.Write(el.StateRegistrationInput, "123456789", "Insert State Registration of Assignor to be Registered");
            await util.Write(el.MunicipalRegistrationInput, "987654321", "Insert Municipal Registration of Assignor to be Registered");
            await util.Click(el.ActivitySelect, "Click on Activity Select");
            await util.Write(gen.Filter, "Comércio", "Insert Activity of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption("Comércio"), "Click on Activity option");
            await util.Click(el.PortSelect, "Click on Port Select");
            await util.Write(gen.Filter, "Médio", "Insert Port of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption("Médio"), "Click on Port option");
            await util.Write(el.EmailINput, "teste@email.com.br", "Insert Email to be registered");
            await util.Click(el.TypeSocietySelect, "Click on Type of Society Select");
            await util.Write(gen.Filter, "LTDA", "Insert Type of Society to be Registered");
            await util.Click(gen.ReceiveTypeOption("LTDA"), "Click on Type of Society option");
            await util.Click(el.RiskClassificationSelect, "Click on Risk Classification Select");
            await util.Write(gen.Filter, "Baixo", "Insert Risk Classification to be Registered");
            await util.Click(gen.ReceiveTypeOption("Baixo"), "Click on Risk Classification option");
            await util.Write(el.AnnualBilling, "5000000", "Insert Annual Billing to be Registered");
            await util.Click(el.Authorization(true),"Click on Authorization Radio Button to be Registered");

            //Location
            await util.Write(el.PostalCodeInput, "01310-000", "Insert Postal Code to be Registered");
            await util.Write(el.AddressInput, "Avenida Paulista", "Insert Address to be Registered");
            await util.Write(el.NumberInput, "1000", "Insert Number to be Registered");
            await util.Write(el.ComplementInput, "10º Andar", "Insert Complement to be Registered");
            await util.Write(el.NeighborhoodInput, "Bela Vista", "Insert Neighborhood to be Registered");
            await util.Write(el.CityInput, "São Paulo", "Insert City to be Registered");
            await util.Click(el.UfSelect, "Click on UF Select");
            await util.Write(gen.Filter, "SP", "Insert UF to be Registered");
            await util.Click(gen.ReceiveTypeOption("SP"), "Click on UF option");
            await util.Write(el.TelInput, "1130000000", "Insert Telephone to be Registered");

            //Tax Data 
            await util.Write(el.EconomicConglomerateInput, "Conglomerado Teste Zitec", "Insert Economic Conglomerate to be Registered");
            await util.Write(el.AssignorPerAproveInput, "80", "Insert Assignor Percentage to be Approved to be Registered");
            await util.Write(el.CreditLimitInput, "1000000", "Insert Credit Limit to be Registered");
            await util.Click(el.IsCoobrigationSelect, "Click on Is Coobrigation Select");
            await util.Write(gen.Filter, "Não", "Insert Is Coobrigation to be Registered");
            await util.Click(gen.ReceiveTypeOption("Não"), "Click on Is Coobrigation option");


        }



    }
}
