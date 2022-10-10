using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater_App.Services.Template
{
    public class CustomersTemplate : TemplateMethod
    {
        protected override bool EditValue(string userId, int Value)
        {
            foreach (var user in _Registered.GetCustomers())
            {
                if (user.Id == userId)
                {
                    user.Credits += Value;
                    _Registered.EditCustomer(user);
                    return true;
                }
            }
            return false;
        }

        protected override object GetList()
        {
            return _Registered.GetCustomers();
        }
    }
}
