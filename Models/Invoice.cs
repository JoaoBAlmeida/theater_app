using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater_App.Models
{
    public class Invoice
    {
        public string UserID { get; set; }
        public List<Performance> Performances { get; set; }
    }
}
