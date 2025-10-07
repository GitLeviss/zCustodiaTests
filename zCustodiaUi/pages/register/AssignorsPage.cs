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

        // Your existing list of Cnpjs
        private static readonly List<string> Cnpjs = new List<string>
    {
            "50.897.660/0001-95","04.149.514/0001-30","71.506.168/0001-60","34.237.939/0001-17",
            "62.238.730/0001-79","23.706.378/0001-00","89.311.874/0001-73","54.582.256/0001-83"
            ,"74.419.416/0001-85","06.148.729/0001-96","67.331.052/0001-11","42.773.324/0001-02"
            ,"49.767.767/0001-30","48.231.612/0001-11","68.636.360/0001-18","45.958.748/0001-30"
            ,"13.196.407/0001-88","46.852.227/0001-66","29.901.963/0001-48","64.467.454/0001-50"
            ,"55.351.094/0001-35","43.477.655/0001-68","03.166.058/0001-06","42.638.556/0001-58"
            ,"48.374.612/0001-70","28.366.571/0001-63","12.052.264/0001-78","84.494.164/0001-02"
    };

        private static readonly Random _random = new Random();

        public string GetCnpjAssignor()
        {
            this.cnpjAssignor = Cnpjs[Random.Shared.Next(Cnpjs.Count)];
            return this.cnpjAssignor;
        }

        private string cnpjAssignor;
        private string nameAssignor = "Cedente Teste Zitec";
        private string fundAssignor = "Zitec FIDC";

        public async Task CRUD_Assignors()
        {
            cnpjAssignor = GetCnpjAssignor();
            await util.Click(el.AssignorPage, "Click on assignor page to visit page");
            await util.Click(el.NewAssignorButton, "Click on new assignor button to start register");
            await util.Click(el.FormAssignors, "Click on Form Assignors button to start register");
            await Task.Delay(500);
            //General Data
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on fund select");
            await util.Write(gen.Filter, fundAssignor, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(fundAssignor), "Click on fund option");
            await Task.Delay(100);
            await util.Write(gen.LocatorMatLabel("Nome"), nameAssignor, "Insert Name of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("CNPJ"), cnpjAssignor, "Insert CNPJ of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("Inscrição Estadual"), "123456789", "Insert State Registration of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("Inscrição Municipal"), "987654321", "Insert Municipal Registration of Assignor to be Registered");
            await Task.Delay(150);

            await util.Click(gen.LocatorMatLabel("Ramo de Atividade"), "Click on Activity Select");
            await util.Write(gen.Filter, "COMÉRCIO", "Insert Activity of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption("COMÉRCIO"), "Click on Activity option");
            await Task.Delay(150);

            await util.Click(gen.LocatorMatLabel("Porte"), "COMÉRCIO on Port Select");
            await util.Write(gen.Filter, "Médio", "Insert Port of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption("Médio"), "Click on Port option");
            await Task.Delay(150);
            await util.Write(gen.LocatorMatLabel("Email"), "teste@email.com.br", "Insert Email to be registered");

            await util.Click(gen.LocatorMatLabel("Tipo de Sociedade"), "Click on Type of Society Select");
            await util.Write(gen.Filter, "LTDA", "Insert Type of Society to be Registered");
            await util.Click(gen.ReceiveTypeOption("LTDA"), "Click on Type of Society option");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Classificação de Risco"), "Click on Risk Classification Select");
            await util.Write(gen.Filter, "Baixo", "Insert Risk Classification to be Registered");
            await util.Click(gen.ReceiveTypeOption("Baixo"), "Click on Risk Classification option");

            await util.Write(gen.LocatorMatLabel("Faturamento Anual"), "50000000", "Insert Annual Billing to be Registered");
            await page.Keyboard.PressAsync("Space");
            await util.Click(el.Authorization(true), "Click on Authorization Radio Button to be Registered");

            //Location
            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("CEP"), "Scroll to CEP");

            await util.Write(gen.LocatorMatLabel("CEP"), "01310-000", "Insert Postal Code to be Registered");
            await util.Write(gen.LocatorMatLabel("Endereço"), "Avenida Paulista", "Insert Address to be Registered");
            await util.Write(gen.LocatorMatLabel("Número"), "1000", "Insert Number to be Registered");
            await util.Write(gen.LocatorMatLabel("Complemento"), "10º Andar", "Insert Complement to be Registered");
            await util.Write(gen.LocatorMatLabel("Bairro"), "Bela Vista", "Insert Neighborhood to be Registered");
            await util.Write(gen.LocatorMatLabel("Cidade"), "São Paulo", "Insert City to be Registered");

            await util.Click(gen.LocatorMatLabel("UF"), "Click on UF Select");
            await util.Write(gen.Filter, "São Paulo", "Insert UF to be Registered");
            await util.Click(gen.ReceiveTypeOption("São Paulo"), "Click on UF option");
            await Task.Delay(150);

            await util.Write(el.TelInput, "1130000000", "Insert Telephone to be Registered");

            //Tax Data 
            await util.Write(gen.LocatorMatLabel("Conglomerado Econômico"), "Conglomerado Teste Zitec", "Insert Economic Conglomerate to be Registered");
            await util.Write(gen.LocatorMatLabel("Número mínimo de assinaturas para aprovação"), "80", "Insert Assignor Percentage to be Approved to be Registered");
            await util.Write(gen.LocatorMatLabel("Limite de Crédito"), "1000000", "Insert Credit Limit to be Registered");
            await page.Keyboard.PressAsync("Space");
            await Task.Delay(150);

            await util.Click(gen.LocatorMatLabel("Coobrigação"), "Click on Is Coobrigation Select");
            await util.Write(gen.Filter, "Não", "Insert Is Coobrigation to be Registered");
            await util.Click(gen.ReceiveTypeOption("Não"), "Click on Is Coobrigation option");

            //Data Account

            await util.ClickMatTabAsync(gen.TabAllForms("Dados da Conta"), "Click on Data Account tab to fill data");
            await Task.Delay(600);
            await util.Click(gen.ButtonNew, "Click in New to insert a New Account");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Banco"), "Insert Bank Number to be Registered");
            await util.Write(gen.Filter, "439 - ID CTVM", "Insert Is Coobrigation to be Registered");
            await util.Click(gen.ReceiveTypeOption("439 - ID CTVM"), "Click on Is Coobrigation option");

            await util.Write(gen.LocatorMatLabel("Número Agência"), "1", "Insert Agency Number to be Registered");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), "46677", "Insert Account Number to be Registered");
            await util.Write("(" + gen.LocatorMatLabel("Dígito") + ")[2]", "3", "Insert Account Digit to be Registered");
            await util.Write(gen.LocatorMatLabel("Descrição"), "Teste", "Click on Account Type Select");
            await util.Click(el.Pattern(true), "Click on Active Account");
            await util.Click(gen.AddButton, "Click on Add Button to add new account");

            //Representative
            await util.ClickMatTabAsync(gen.TabAllForms("Representante"), "Click on Representative tab to fill data");
            await Task.Delay(600);
            await util.Click(gen.ButtonNew, "Click in New to insert a New Account");
            await util.Write(gen.LocatorMatLabel("Nome"), "Representante Teste Zitec", "Insert Name of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("E-mail"), "email@representantetestZitec.ai", "Insert E-mail of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("CPF"), "40956114806", "Insert CPF of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("Telefone"), "11934125767", "Insert Telephone of Representative to be Registered");
            await util.Click(el.Assign(true), "Click on 'yes' to Assign");
            await util.Click(el.AssignTerm(true), "Click on 'yes' to Assign Term");
            await util.Click(el.AssignByEndorsement(true), "Click on 'yes' to Assign By Endorsement");
            await util.Click(el.IssueDouble(true), "Click on 'yes' to Issue Double");
            await util.Click(gen.AddButton, "Click on Add button to add new Assignor");
            await Task.Delay(1500);
            await util.Click(gen.SaveButton, "Click on Add button to add new Representative");
            await util.ValidateTextIsVisibleInScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen");

            //Consult Assignor
            await page.ReloadAsync();
            await util.Click(gen.FilterButton, "Click on Filter Button to filter Assignor to be consulted");
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on Filter Select to filter Assignor to be consulted");
            await util.Write(gen.Filter, fundAssignor, "Insert Find Assignor to be consulted");
            await util.Click(gen.ReceiveTypeOption(fundAssignor), $"Click on {fundAssignor} option");
            await util.Write(gen.LocatorMatLabel("Nome Cedente"), nameAssignor, "Insert Name Assignor to be consulted");
            await util.Write(gen.LocatorMatLabel("CNPJ"), cnpjAssignor, "Insert CNPJ Assignor to be consulted");
            await util.Click(el.ApplyFilterButton, "Click on Apply Filter Button to show results");
            await Task.Delay(1000);
            await util.ValidateIfElementHaveValue(el.IdPosition, "Validate If ID of assignor is present on screen");

            //Update Assignor
            await util.Click(gen.EditButton, "Click on Edit button to update Assignor");
            await Task.Delay(150);
            await util.Write(gen.LocatorMatLabel("Nome"), "Cedente Teste Zitec EDITADO", "Insert Name EDITED of Assignor to be Registered");
            await util.Click(gen.SaveButton, "Click on Add button to add EDITED Assignor");
            await util.ValidateTextIsVisibleInScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen");

            //Pending -> Delete Assignor

        }



    }
}
