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
    public class FundsPage
    {
        private readonly Utils util;
        private readonly FundsElements el = new FundsElements();
        private readonly GenericElements gen = new GenericElements();
        private readonly IPage page;
        public FundsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task RegisterNewFund()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();


            //Register Data
            await util.Click(el.FundsPage, "Open Funds page");
            await util.Click(gen.ButtonNew, "Open New Fund form");
            await util.Write(el.FundName, "Quality Assurance Fundo", "Write Fund Name");
            await util.Write(el.Cnpj, "52721175000191", "Write CNPJ");
            await util.Write(el.IsinCode, "000000000000001", "Write ISIN Code");
            await util.Write(el.AnbidCode, "1234567890", "Write ANBID Code");

            await util.Click(el.TypeFundSelect, "Write Type Fund");
            await util.Write(gen.Filter,"Direitos Creditorios", "Write Type Fund");

            await util.Click(el.TypeFidc, "Select Fidc Type Fund");
            await util.Click(el.StartProcessingCalendar, "Open Start Processing Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(el.CetipNumber, "1234567890", "Write CETIP Number");
            await util.Write(el.CelicNumber, "1234567890", "Write CELIC Number");

            await util.Click(el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(el.SequentialNumberCvm, "2536789811", "Write Sequential Number CVM");

            await util.ScrollToElementAndMaintainPosition(el.CheckSelect, "Scroll to element CheckSelect and keep it visible");
            await util.Click(el.BallastSelect, "Click Ballast Select");
            await util.Write(gen.Filter, " Clube ", "Write Aquisition Select");
            await util.Click(el.BallastClube, "Click Ballast Clube");
            await Task.Delay(100);

            await util.Click(el.CodeSelect, "Click Code Select");
            await util.Write(gen.Filter, " 1 ", "Write Code Select");
            await util.Click(el.Code1, "Click Code 1");
            await Task.Delay(100);

            await util.Click(el.CheckSelect, "Click Check Select");
            await util.Write(gen.Filter, " CNAB160 - Retorno de Cheque ", "Write Check Select");
            await util.Click(el.CheckCNAB160, "Click Check CNAB160");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await util.ScrollToElementAndMaintainPosition(el.NFeKeyReceiptDeadlineInput, "Scroll to NFe Key Receipt Deadline");
            await util.Write(el.NFeKeyReceiptDeadlineInput, "5", "Write NFe Key Receipt Deadline");
            
            await util.Write(el.DeadLineReceptionBallastInput, "5", "Write Deadline Reception Ballast");
            
            await util.ScrollToElementAndMaintainPosition(el.SelectProfileActiveSystem, "Scroll to Profile Active System and maintain position");
                      
            await util.Write(el.DeadLinePddInput, "0", "Write Deadline PDD");
            await util.Write(el.SequenceNumberTermCessionInput, "1001", "Write Sequence Number Term Cession");
            await util.Write(el.SequenceNumberTermRepurchaseInput, "1002", "Write Sequence Number Term Repurchase");
            await util.Write(el.QuantityDaysImportPlInput, "10", "Write Quantity Days Import PL");
            await util.Write(el.AgreementInput, "12345", "Write Agreement");
            await util.Write(el.MaxValueToAssignRobotInput, "10000", "Write Max Value To Assign Robot");
            
            await util.ScrollToElementAndMaintainPosition(el.SelectReceiveType, "Scroll to Receive Type and maintain position");
            await util.Click(el.SelectReceiveType, "Click Receive Type");
            await util.Write(gen.Filter, "Duplicata", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Receive Type Option");
            
            await util.Write(el.WalletCodeInput, "001", "Write Wallet Code");
            await util.Write(el.ProcessOrderInput, "99999", "Write Process Order");

            
            //Rules 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Regras"), "Scroll to belt to change form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Regras"), "Click belt to change form");

            await util.Click(el.RuleNameSelect, "Click on select to expand options of name rules");
            await util.Click(el.FirstRuleNameOfList, "Click on select to expand options of name rules");

            await util.Click(el.RelationshipCalendar, "Click on relationship callendar to expand the callendar");
            await util.Click(gen.DayValue(today), "Click on tomorrow day to set relationship date");

            await util.Click(el.PriceModelSelect, "Click to expand price model select");
            await util.Click(el.FirstPriceModelOfList, "Click first price model of list");

            await util.Click(el.ApplyToSelect, "Click on select to expand options of apply to");
            await util.Click(el.FirstApplyToOfList, "Click on first option of apply to");

            //Representatives
            await util.Click(gen.TabAllForms("Representantes"), "Click belt to change form");

            await util.Click(gen.ButtonNew, "Click on button new to add new representative");

            await util.Click(el.NameRepresentative, "Click on the name representative input");
            await util.Write(el.NameRepresentative,"Representante Teste", "Click on the name representative input");

            await util.Write(el.EmailRepresentative,"teste@email.com","insert email representative on input");

            await util.Write(el.Cpf, "40956114806", "Write on the CPF representative input");
            await util.Write(el.Tel, "11934125767", "Write on the Tel input");

            await util.Click(el.AssignRadio(true), "Select 'yes' to assign");
            await util.Click(el.SignsByEndorsementRadio(true), "Select 'yes' to Signs By Endorsement");
            await util.Click(el.AssignTermRadio(true), "Select 'yes' to assign Term");
            await util.Click(el.IssuesDuplicateRadio(true), "Select 'yes' to Issue Duplicate");

            await util.Click(el.AddButton, "Click on add to add representative on fund");

            //Liquidation 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Liquidação"), "Scroll to belt to change form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Liquidação"), "Click belt to change form");

            await util.Write(el.MaxPercentReimbusement, "10", "Set max percent of reimbursement");

            //Account
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Conta Corrente"), "Scroll to belt to change form");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Conta Corrente"), "Click belt to change form");

            await util.Click(gen.ButtonNew, "Click on button new to insert a new Account");
            await util.Click(el.BankSelect, "Click on BankSelect button new to insert a new Bank");
            await util.Write(gen.Filter, "ID CTVM", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("439 - ID CTVM"), "Click Receive Type Option");
            await util.Write(el.NumberAgencyInput, "1", "Write Number Agency");
            await util.Write(el.NumberAccountInput, "46677", "Write Number account");
            await util.Write(el.NumberCodeInput, "3", "Write Code account");
            await util.Click(el.PatternAccount(true), "Click on 'yes' to account pattern");
            await util.Click(el.MovementType("Movimentação"), "Click on Movement Type");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");


            //slack
            await util.ClickMatTabAsync(gen.TabAllForms("Slack"), "Click belt to change form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await util.Write(el.WebHookOperationsInput, "WebHook Test", "Insert name of operations webhook");            
            await util.Write(el.NameChannelOperationsInput, "Channel Test", "Insert Name Of Channel Operations");
            await util.Write(el.IDChannelOperationsInput, "01", "Insert ID of Channel Operations");

            await util.Write(el.WebHookBallastInput, "WebHook Test", "Insert name of operations webhook");
            await util.Write(el.NameChannelBallastInput, "Channel Test", "Insert Name Of Channel Operations");            
            await util.Write(el.IDChannelBallastInput, "01", "Insert ID of Channel Operations");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");

            //File Validation
            await util.ClickMatTabAsync(gen.TabAllForms("Validação Arquivo"), "Click belt to change form");
            await util.Click(el.ReceiveAllowToFund, "Click on button new to Receives allow to fund");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Duplicata Type Option");
            await page.Keyboard.PressAsync("Escape");


            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await util.ClickMatTabAsync(gen.TabAllForms("Prestadores de Serviços"), "Click belt to change form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await util.Click(el.ProviderTypeSelect, "Select Type Provider in new provider");
            await util.Click(gen.ReceiveTypeOption("Administrador"), "Click Receive Type Option");
            await util.Click(el.PersonSelect, "Select Type Person Type in new provider");
            await util.Click(gen.ReceiveTypeOption("ORIGINADOR QA"), "Click Receive Type Option");
            await util.Click(el.ChargeTypeSelect, "Select Charge Type Select in new provider");
            await util.Click(gen.ReceiveTypeOption("Valor Fixo"), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(el.FixedValue, "100000", "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            await util.Click(el.SaveButton, "Click on to add a new Fund!");
            await util.ValidateReturnedMessageIsVisible(el.SuccessMessage, "Validate if success message is present on screen");


        }


        public async Task ConsultFund()
        {
            string fundName = "ZITEC FIDC";

            await util.Click(el.FundsPage, "Open Funds page");
            await util.Write(el.SearchBar, fundName, "Write on filter input to find the fund created");
            await Task.Delay(1000);
            await util.ValidateElementPresentOnTheTable(page, el.FundTable, fundName, "Validate if Text is present on table");
        }

        public async Task UpdateFund()
        {
                       string fundName = "FUNDO QA";
            await util.Click(el.FundsPage, "Open Funds page");
            await util.Write(el.SearchBar, fundName, "Write on filter input to find the fund created");
            await Task.Delay(600);
            await util.ValidateTextIsVisible(el.NameFundTable, fundName, "Validate if Text is present on table");
            await util.Click(el.EditButton, "Click on Edit button to edit the Fund");
            //Make changes
            await util.Write(el.IsinCode, "000000000000001", "Edit Code isin");
            await util.ScrollToElementAndMaintainPosition(el.ApplyChangesButton, "Scroll to Button apply changes");

            await util.Click(el.ApplyChangesButton, "Click on to save the Fund!");
            await util.ValidateReturnedMessageIsVisible(el.SuccessMessage, "Validate if success message is present on screen");
        }

    }

        
        
}