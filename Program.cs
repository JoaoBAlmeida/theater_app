using System;
using Theater_App.Models;
using Theater_App.Repositories;
using Theater_App.Services.Money;
using Theater_App.Services.Template;

namespace Theater_App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            StatementOrganizer DebtCollector = new StatementOrganizer(new InvoicesTemplate(), new PlaysTemplate(), new CustomersTemplate());
            DebtCollector.GenerateStatement();
        }
    }
}