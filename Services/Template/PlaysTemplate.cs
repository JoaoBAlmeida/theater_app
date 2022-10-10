using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater_App.Services.Template
{
    public class PlaysTemplate : TemplateMethod
    {
        protected override bool EditValue(string userId, int Value)
        {
            throw new NotImplementedException();
        }

        protected override object GetList()
        {
            return _presented.GetPlays();
        }
    }
}
