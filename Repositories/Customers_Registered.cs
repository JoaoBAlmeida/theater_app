using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Models;

namespace Theater_App.Repositories
{
    public class Customers_Registered
    {
        private List<Customer> Customers { get; set; }
        public Customers_Registered()
        {
            this.Customers = new List<Customer>
            {
                new Customer
                {
                    Id = "BC01",
                    Name = "BigCo",
                    Credits = 0
                },
                new Customer
                {
                    Id = "ThirdImp",
                    Name = "Third Implementation",
                    Credits= 0
                }
            };
        }
        public List<Customer> GetCustomers()
        {
            return Customers;
        }
        public bool EditCustomer(Customer newCust)
        {
            int index = Customers.FindIndex(x => x.Id.Equals(newCust.Id));
            if (index == -1) return false;
            Customers[index] = newCust;
            return true;
        }
    }
}
