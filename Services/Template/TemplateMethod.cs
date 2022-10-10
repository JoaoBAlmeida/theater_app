using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Repositories;

namespace Theater_App.Services.Template
{
    public abstract class TemplateMethod
    {
        //This section could and should be substituted by a call to a Database
        protected Invoices_Asked _invoices = new Invoices_Asked();
        protected Plays_Presented _presented = new Plays_Presented();
        protected Customers_Registered _Registered = new Customers_Registered();

        public object ShowValues()
        {
            return GetList();
        }

        public bool Edit(string userId, int Value)
        {
            return EditValue(userId, Value);
        }

        //Section for inheritors to override
        protected abstract object GetList();
        protected abstract bool EditValue(string userId, int Value);
    }
}
