using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Models;

namespace Theater_App.Repositories
{
    public class Invoices_Asked
    {
        private List<Invoice> Invoices { get; set; }
        public Invoices_Asked()
        {
            this.Invoices = new List<Invoice>
            {
                new Invoice
                {
                    UserID = "BC01",
                    Performances = new List<Performance>
                    {
                        new Performance
                        {
                            PlayID = "hamlet",
                            Audience_Num = 55
                        },
                        new Performance
                        {
                            PlayID = "as-like",
                            Audience_Num = 35
                        },
                        new Performance
                        {
                            PlayID = "othello",
                            Audience_Num = 40
                        }
                    } 
                },
                //Newly added
                new Invoice
                {
                    UserID = "ThirdImp",
                    Performances = new List<Performance>
                    {
                        new Performance
                        {
                            PlayID = "ghosts",
                            Audience_Num = 25
                        }
                    }
                }
            };
        }
        public List<Invoice> GetInvoices()
        {
            return Invoices;
        }
    }
}
