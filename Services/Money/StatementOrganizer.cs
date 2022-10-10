using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Models;
using Theater_App.Repositories;
using Theater_App.Services.Receipt;
using Theater_App.Services.Template;

namespace Theater_App.Services.Money
{
    public class StatementOrganizer
    {
        InvoicesTemplate _inv;
        PlaysTemplate _pl;
        CustomersTemplate _cust;
        public StatementOrganizer(InvoicesTemplate _invoices, PlaysTemplate _plays, CustomersTemplate _customers)
        {
            _inv = _invoices;
            _pl = _plays;
            _cust = _customers;
        }

        public void GenerateStatement()
        {
            PrintReceipt pRec = new PrintReceipt();
            int opt = 1;
            List<Customer> customers = GetCustomers();
            while (opt != 0)
            {
                Console.WriteLine("Choose your Option: \n");
                int loop = 1;
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(loop + ": " + customer.Name);
                    loop++;
                }
                Console.WriteLine("0: Cancel & Exit");
                try
                {
                    opt = int.Parse(Console.ReadLine());
                    if (0 > opt || opt > loop)
                    {
                        throw new Exception("Invalid Charater inserted\nPlease try again!\n\n");
                    }

                    //Create .txt file with statement
                    bool result = pRec.Print(customers[opt - 1].Name + "_receipt",
                        GetStatement(customers[opt - 1]));
                    if (result)
                    {
                        Console.WriteLine("Statement sucessfully generated!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, statement could not be generated");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Clear();
            return;
        }

        //Function could be improved upon - Four separate functions
        //Fisrt occurrence, last occurrence, any occurrence or all occurrences from the user
        private string GetStatement(Customer customer)
        {
            PricingCalculator pCalc = new PricingCalculator();
            string returnable = "";
            List<Invoice> invoices = GetInvoices();
            Invoice _invoice = invoices.Where(x => x.UserID.Equals(customer.Id)).Last();

            //First part of returnable statement
            returnable = "Statement for " + customer.Name + "\n";

            float price = 0;
            int credit = 0;
            List<Play> plays = GetPlays();
            foreach (Performance perf in _invoice.Performances)
            {
                string playtype = plays.Where(x => x.Id.Equals(perf.PlayID)).First().Type;
                string playName = plays.Where(x => x.Id.Equals(perf.PlayID)).First().Name;

                float price_temp = pCalc.AddPrice(playtype, perf.Audience_Num);
                price += price_temp;

                //Check if user would like to see the info on the statement
                string opt = CollectConfirmation(playName);
                if (opt.ToUpper() == "Y")
                {
                    returnable += string.Format("\t" + playName + ": ${0:C} (" +
                        perf.Audience_Num + " seats)\n", price_temp / 100);
                }

                credit += pCalc.AddCredit(playtype, perf.Audience_Num);
            }

            //Add credits to user - Function better developed to BD contact
            _cust.Edit(customer.Id, credit);

            //Check if user would like info on the statement
            string opt2 = CollectConfirmation("Amount owed & Credits Earned");
            if (opt2.ToUpper() == "Y")
            {
                returnable += string.Format("Amount owed is ${0:C}\n", price / 100);
                returnable += string.Format("You earned {0} credits\n", credit);
            }

            /*Change delivery to .txt file
            Console.Clear();
            Console.WriteLine(returnable);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            */

            return returnable;
        }

        private string CollectConfirmation(string info)
        {
            Console.WriteLine("Would you like to see " + info + " info on the statement? Press Y to confirm\n");
            return Console.ReadLine();
        }

        //Functions to turn everything into List
        private List<Play> GetPlays()
        {
            return (List<Play>)_pl.ShowValues();
        }

        private List<Customer> GetCustomers()
        {
            return (List<Customer>)_cust.ShowValues();
        }

        private List<Invoice> GetInvoices()
        {
            return (List<Invoice>)_inv.ShowValues();
        }
    }
}
