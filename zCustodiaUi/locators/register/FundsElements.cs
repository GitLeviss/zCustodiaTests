using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.register
{
    public class FundsElements
    {
        #region Form Registration Data
        //Form Registration Data
        //Name and CNPJ
        public string FundsPage { get; } = "//span[text()='Fundos']";
        public string ButtonNewFund { get; } = "//span[text()='Novo']";
        public string FundName { get; } = "#input-nome";
        public string Cnpj { get; } = "#input-cnpj";
        public string IsinCode { get; } = "#input-codigoISIN";
        public string AnbidCode { get; } = "#input-codigoANBID";
        public string TypeFundSelect { get; } = "#select-tipoFundo";
        public string StartProcessingCalendar { get; } = "(//button[@aria-label='Open calendar'])[1]";
        public string EndProcessingCalendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string DeadlineCalendar { get; } = "(//button[@aria-label='Open calendar'])[3]";
        public string CetipNumber { get; } = "#input-numeroCETIP";
        public string CelicNumber { get; } = "#input-nmrCelic";
        public string CvmRegisterCalendar { get; } = "(//button[@aria-label='Open calendar'])[4]";
        public string SequentialNumberCvm { get; } = "#input-numeroSequencialCVM";

        //Layouts

        public string AquisitionSelect { get; } = "#select-layoutAquisicao";
        public string OcurrencySelect { get; } = "#mat-select-value-11";
        public string BallastSelect { get; } = "#mat-select-value-11";
        public string CodeSelect { get; } = "#mat-select-value-15";
        public string CheckSelect { get; } = "#mat-select-value-17";
        public string LayoutSelect { get; } = "#mat-select-value-19";

        //Permissions and Qualifications

        public string RateTypeUpdated(bool isMonthly) => $"mat-radio-{(isMonthly ? "17" : "18")}";
        public string ClosedEndFundOpeningProcess (bool isTrue) => $"mat-radio-{(isTrue ? "20" : "21")}";
        public string BlockAssignor (bool isTrue) => $"mat-radio-{(isTrue ? "23" : "24")}";
        public string EnableWhiteOff (bool isTrue) => $"mat-radio-{(isTrue ? "26" : "27")}";
        public string EnableCCBcalculation (bool isTrue) => $"mat-radio-{(isTrue ? "29" : "30")}";
        public string EnablesReducedXml (bool isTrue) => $"mat-radio-{(isTrue ? "32" : "33")}";
        public string ActivateImportPendingAssetSystem (bool isTrue) => $"mat-radio-{(isTrue ? "35" : "36")}";
        public string EnablesValuationOfOverduePayments (bool isTrue) => $"mat-radio-{(isTrue ? "38" : "39")}";
        public string CheckContractsAtRegisterC3 (bool isTrue) => $"mat-radio-{(isTrue ? "41" : "42")}";
        public string HighVolumetry (bool isTrue) => $"mat-radio-{(isTrue ? "44" : "45")}";
        public string EnableAssignRobot (bool isTrue) => $"mat-radio-{(isTrue ? "47" : "48")}";
        public string SentEmailNotification (bool isTrue) => $"mat-radio-{(isTrue ? "50" : "51")}";
        public string WorksWithReceivingUnits (bool isTrue) => $"mat-radio-{(isTrue ? "53" : "54")}";
        public string QualificationClassification (bool isTrue) => $"mat-radio-{(isTrue ? "56" : "57")}";
        public string DilutionOfReceivingUnits (bool isTrue) => $"mat-radio-{(isTrue ? "59" : "60")}";
        public string ConsiderPostFixed (bool isTrue) => $"mat-radio-{(isTrue ? "62" : "63")}";
        public string AuthorizesAutomaticFundClosure (bool isTrue) => $"mat-radio-{(isTrue ? "65" : "66")}";
        public string ZeroPl (bool isTrue) => $"mat-radio-{(isTrue ? "68" : "69")}";
        public string IntegrateAccounting (bool isTrue) => $"mat-radio-{(isTrue ? "71": "72")}";
        public string DisplaysIndexInformationInTheStockReport (bool isTrue) => $"mat-radio-{(isTrue ? "74" : "75")}";
        public string GenerateStockAfterClosingFund (bool isTrue) => $"mat-radio-{(isTrue ? "77" : "78")}";
        public string GeneratesStockAttorney (bool isTrue) => $"mat-radio-{(isTrue ? "80" : "81")}";
        public string ConsiderDueOnClosingDate (bool isTrue) => $"mat-radio-{(isTrue ? "83" : "84")}";
        public string EnablesGeneratePortalStock (bool isTrue) => $"mat-radio-{(isTrue ? "86" : "87")}";
        public string RegisterAssignorAutomated (bool isTrue) => $"mat-radio-{(isTrue ? "89" : "90")}";
        public string EnableGlobalPdd (bool isTrue) => $"mat-radio-{(isTrue ? "92" : "93")}";
        public string WalletSystemIntegrationProcessor (bool isTrue) => $"mat-radio-{(isTrue ? "95" : "96")}";

        //Others

        public string NFeKeyReceiptDeadlineInput { get; } = "#input-prazoRecepcaoChaveNfe";
        public string DataCalendar { get; } = "//button[@aria-label='Calendário aberto']";
        public string DeadLineReceptionBallastInput { get; } = "#input-prazoRecepcaoLastro";
        public string SelectProfileActiveSystem { get; } = "#select-perfilLiquidacaoSistemaAtivos";
        public string DeadLinePddInput { get; } = "#input-prazoPDD";
        public string SequenceNumberTermCessionInput { get; } = "#input-numeroSequencialAttTermoCessao";
        public string SequenceNumberTermRepurchaseInput { get; } = "#input-numeroSequencialAttTermoRecompra";
        public string QuantityDaysImportPlInput { get; } = "#input-qtdDiasRetroagirImportacaoPL";
        public string AgreementInput { get; } = "#input-convenio";
        public string MaxValueToAssignRobotInput { get; } = "#input-valorMaximoRoboAssinatura";
        public string SelectReceiveType { get; } = "#mat-select-value-23";
        public string WalletCodeInput { get; } = "#input-codigoCarteira";
        public string ProcessOrderInput { get; } = "#input-ordemProcessamento";

        #endregion Form Registration Data


    }

}
