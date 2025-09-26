using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class FundsPage
    {
        private readonly Utils util;
        private readonly FundsElements el = new FundsElements();
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

            await util.Click(el.FundsPage, "Open Funds page");
            await util.Click(el.ButtonNewFund, "Open New Fund form");
            await util.Write(el.FundName, "Teste", "Write Fund Name");
            await util.Write(el.Cnpj, "52721175000191", "Write CNPJ");
            await util.Write(el.IsinCode, "1234567890", "Write ISIN Code");
            await util.Write(el.AnbidCode, "1234567890", "Write ANBID Code");

            await util.Click(el.TypeFundSelect, "Write Type Fund");
            await util.Write(el.Filter,"Direitos Creditorios", "Write Type Fund");

            await util.Click(el.TypeFidc, "Select Fidc Type Fund");
            await util.Click(el.StartProcessingCalendar, "Open Start Processing Calendar");
            await util.Click(el.DayValue(today), "Set Today day on calendar");

            await util.Write(el.CetipNumber, "1234567890", "Write CETIP Number");
            await util.Write(el.CelicNumber, "1234567890", "Write CELIC Number");

            await util.Click(el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await util.Click(el.DayValue(today), "Set Today day on calendar");

            await util.Write(el.SequentialNumberCvm, "2536789811", "Write Sequential Number CVM");

            //await util.Click(el.AquisitionSelect, "Click Aquisition Select");
            //await util.Write(el.Filter, "CNAB400 - REMESSA (SOCOPA - V2) - HEADER 01", "Write Aquisition Select");

            //await util.Click(el.OcurrencySelect, "Click Ocurrency Select");
            //await util.Write(el.Filter, "CNAB400 - REMESSA (SOCOPA - V2) - HEADER 01", "Write Aquisition Select");

            await util.ScrollToElementAndMaintainPosition(el.CheckSelect, "Scroll to element CheckSelect and keep it visible");
            await util.Click(el.BallastSelect, "Click Ballast Select");
            await util.Write(el.Filter, " Clube ", "Write Aquisition Select");
            await util.Click(el.BallastClube, "Click Ballast Clube");
            await Task.Delay(100);

            await util.Click(el.CodeSelect, "Click Code Select");
            await util.Write(el.Filter, " 1 ", "Write Code Select");
            await util.Click(el.Code1, "Click Code 1");
            await Task.Delay(100);

            await util.Click(el.CheckSelect, "Click Check Select");
            await util.Write(el.Filter, " CNAB160 - Retorno de Cheque ", "Write Check Select");
            await util.Click(el.CheckCNAB160, "Click Check CNAB160");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await util.ScrollToElementAndMaintainPosition(el.NFeKeyReceiptDeadlineInput, "Scroll to NFe Key Receipt Deadline");
            await util.Write(el.NFeKeyReceiptDeadlineInput, "30", "Write NFe Key Receipt Deadline");
            
            await util.Write(el.DeadLineReceptionBallastInput, "15", "Write Deadline Reception Ballast");
            
            await util.ScrollToElementAndMaintainPosition(el.SelectProfileActiveSystem, "Scroll to Profile Active System and maintain position");
                      
            await util.Write(el.DeadLinePddInput, "5", "Write Deadline PDD");
            await util.Write(el.SequenceNumberTermCessionInput, "1001", "Write Sequence Number Term Cession");
            await util.Write(el.SequenceNumberTermRepurchaseInput, "1002", "Write Sequence Number Term Repurchase");
            await util.Write(el.QuantityDaysImportPlInput, "10", "Write Quantity Days Import PL");
            await util.Write(el.AgreementInput, "12345", "Write Agreement");
            await util.Write(el.MaxValueToAssignRobotInput, "1000000", "Write Max Value To Assign Robot");
            
            await util.ScrollToElementAndMaintainPosition(el.SelectReceiveType, "Scroll to Receive Type and maintain position");
            await util.Click(el.SelectReceiveType, "Click Receive Type");
            await util.Write(el.Filter, "Duplicata", "Write Receive Type");
            await util.Click(el.ReceiveTypeOption("Duplicata"), "Click Receive Type Option");
            
            await util.Write(el.WalletCodeInput, "WALLET001", "Write Wallet Code");
            await util.Write(el.ProcessOrderInput, "1", "Write Process Order");

            // Set mandatory radio buttons (default to false for most)

            //await util.Click(el.BlockAssignor(false), "Click Block Assignor - No");
            //await util.Click(el.EnableWhiteOff(false), "Click Enable White Off - No");
            //await util.Click(el.EnableCCBcalculation(false), "Click Enable CCB calculation - No");
            //await util.Click(el.EnablesReducedXml(false), "Click Enables Reduced XML - No");
            //await util.Click(el.ActivateImportPendingAssetSystem(false), "Click Activate Import Pending Asset System - No");
            //await util.Click(el.EnablesValuationOfOverduePayments(false), "Click Enables Valuation Of Overdue Payments - No");
            //await util.Click(el.CheckContractsAtRegisterC3(false), "Click Check Contracts At Register C3 - No");
            //await util.Click(el.HighVolumetry(false), "Click High Volumetry - No");
            //await util.Click(el.EnableAssignRobot(false), "Click Enable Assign Robot - No");
            //await util.Click(el.SentEmailNotification(false), "Click Sent Email Notification - No");
            //await util.Click(el.WorksWithReceivingUnits(false), "Click Works With Receiving Units - No");
            //await util.Click(el.QualificationClassification(false), "Click Qualification Classification - No");
            //await util.Click(el.DilutionOfReceivingUnits(false), "Click Dilution Of Receiving Units - No");
            //await util.Click(el.ConsiderPostFixed(false), "Click Consider Post Fixed - No");
            //await util.Click(el.AuthorizesAutomaticFundClosure(false), "Click Authorizes Automatic Fund Closure - No");
            //await util.Click(el.ZeroPl(false), "Click Zero PL - No");
            //await util.Click(el.IntegrateAccounting(false), "Click Integrate Accounting - No");
            //await util.Click(el.DisplaysIndexInformationInTheStockReport(false), "Click Displays Index Information In The Stock Report - No");
            //await util.Click(el.GenerateStockAfterClosingFund(true), "Click Generate Stock After Closing Fund - Yes");
            //await util.Click(el.GeneratesStockAttorney(false), "Click Generates Stock Attorney - No");
            //await util.Click(el.ConsiderDueOnClosingDate(false), "Click Consider Due On Closing Date - No");
            //await util.Click(el.EnablesGeneratePortalStock(true), "Click Enables Generate Portal Stock - Yes");
            //await util.Click(el.RegisterAssignorAutomated(false), "Click Register Assignor Automated - No");
            //await util.Click(el.EnableGlobalPdd(false), "Click Enable Global PDD - No");
            //await util.Click(el.WalletSystemIntegrationProcessor(false), "Click Wallet System Integration Processor - No");

            await.Util.Click(el.TabAllForms, "Click on belt to change form");
         
        }


    }

        
        
}