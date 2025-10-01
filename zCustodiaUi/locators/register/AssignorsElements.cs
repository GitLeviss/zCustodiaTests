using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.register
{
    public class AssignorsElements
    {
        //General Data
        public string AssignorPage { get; } = "//span[text()='Cedentes']";
        public string FundSelect { get; } = "#select-fundo";
        public string NewAssignorButton { get; } = "//span[text()=' Novo ']";
        public string FormAssignors { get; } = "//span[text()='Formulário de Cedentes']";
        public string NameInput { get; } = "#input-nome";
        public string CpjCnpjInput { get; } = "#input-cnpjcpf";
        public string StateRegistrationInput { get; } = "#input-inscricaoEstadual";
        public string MunicipalRegistrationInput { get; } = "#input-inscricaoMunicipal";
        public string ActivitySelect { get; } = "#select-ramoAtividade";
        public string PortSelect { get; } = "#select-porte";
        public string EmailINput { get; } = "#input-email";
        public string TypeSocietySelect { get; } = "#select-tipoSociedade";
        public string RiskClassificationSelect { get; } = "#select-classificacaoRisco";
        public string AnnualBilling { get; } = "#mat-input-64";
        public string Authorization (bool isTrue) => $"#mat-radio-{(isTrue ? "254":"255")}";
        
        //Location
        public string PostalCodeInput { get; } = "#mat-input-65";
        public string AddressInput { get; } = "#input-endereco";
        public string NumberInput { get; } = "#input-numero";
        public string ComplementInput { get; } = "#input-complemento";
        public string NeighborhoodInput { get; } = "#input-bairro";
        public string CityInput { get; } = "#input-cidade";
        public string UfSelect { get; } = "#select-uf";
        public string TelInput { get; } = "#input-telefoneDDD";

        //tax data
        public string EconomicConglomerateInput { get; } = "#input-conglomeradoEconomico";
        public string AssignorPerAproveInput { get; } = "#mat-input-74";
        public string CreditLimitInput { get; } = "#mat-input-75";
        public string IsCoobrigationSelect { get; } = "#select-tipoCoobrigacao";

    }
}
