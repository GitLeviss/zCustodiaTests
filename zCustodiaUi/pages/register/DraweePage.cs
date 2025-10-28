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
    public class DraweePage
    {
        private readonly IPage page;
        private readonly Utils util;
        private readonly GenericElements gen = new GenericElements();
        private readonly DraweeElements el = new DraweeElements();
        public DraweePage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }
        

        string cpfTest = DataGenerator.Generate(DocumentType.Cpf);

        public async Task Register_Drawee()
        {
            var today = DateTime.Now.Day.ToString();

            await util.Click(gen.LocatorSpanText("Novo Sacado"), "Click on new drawee button to register a new drawee");
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await util.Write(gen.Filter, "Zitec FIDC","Select Zitec FIDC to choose zitec fund");
            await util.Click(gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");

            await util.Write(gen.LocatorMatLabel("Nome"), "Sacado Zitec Test", "Write drawee name");
            await util.Write(gen.LocatorMatLabel("Email"), "email@teste.com", "Write drawee email");
            await util.Write(gen.LocatorMatLabel("CPF"), cpfTest, "Write drawee email");

            await util.Click(el.CalendarStartRelationship, "Open Calendar Start Relationship");
            await util.Click(el.DayValue(today), "Select Today on calendar of start Relationship");
            await util.Click(el.CalendarEndRelationship, "Open Calendar End Relationship");
            await util.Click(el.DayValue(today), "Select Today on calendar of start Relationship");

            await util.Write(gen.LocatorMatLabel("Conglomerado Econômico"), "123456", "Write drawee economic conglomerate");

            await util.Click(gen.LocatorMatLabel("Porte"),"Click on select size to expand options");
            await util.Write(gen.Filter, "Microempreendedor Individual (MEI)", "Select MEI to choose MEI");
            await util.Click(gen.LocatorSpanText(" Microempreendedor Individual (MEI) "), "Select large size option");

            await util.Click(gen.LocatorMatLabel("Classificação de Risco"),"Click on select risk classification to expand options");
            await util.Write(gen.Filter, "Baixo", "Select low to choose low option");
            await util.Click(gen.LocatorSpanText(" Baixo "), "Select low size option");

            await util.Click(gen.LocatorMatLabel("Tipo de Sociedade"),"Click on select risk classification to expand options");
            await util.Write(gen.Filter, "LTDA", "Select low to choose low option");
            await util.Click(gen.LocatorSpanText(" LTDA "), "Select low size option");

            await util.Write(gen.LocatorMatLabel("Inscrição Estadual"),"123456", "Write state registration");

            await util.Write(gen.LocatorMatLabel("CEP"),"06240190", "Write postal code");
            await util.Write(gen.LocatorMatLabel("Número"),"11934125767", "Write number phone on input number");
            await util.Click(gen.LocatorMatLabel("Telefone(DDD)"), "Click on street after postal code to load address");

            await util.Click(gen.LocatorSpanText("Salvar"),"CLick on save button to save drawee");

        }



    }
}
