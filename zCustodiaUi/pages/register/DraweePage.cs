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
        private readonly AssignorsElements el = new AssignorsElements();
        public DraweePage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }
        

        string cnpjTest = DataGenerator.Generate(DocumentType.Cnpj);

        public async Task CRUD_Drawee()
        {
            


        }



    }
}
