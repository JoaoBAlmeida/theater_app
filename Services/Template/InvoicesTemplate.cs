using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Models;
using Theater_App.Repositories;

namespace Theater_App.Services.Template
{
    public class InvoicesTemplate : TemplateMethod
    {
        protected override bool EditValue(string userId, int Value)
        {
            throw new NotImplementedException();
        }

        protected override object GetList()
        {
            return _invoices.GetInvoices();
        }
    }
}
