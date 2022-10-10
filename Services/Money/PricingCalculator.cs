using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater_App.Services.Money
{
    public class PricingCalculator
    {
        public float AddPrice(string type, int audience)
        {
            float thisAmount;
            switch (type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (audience > 30)
                    {
                        thisAmount += 1000 * (audience - 30);
                    }
                    return thisAmount;
                case "comedy":
                    thisAmount = 30000;
                    if (audience > 20)
                    {
                        thisAmount += 10000 + 500 * (audience - 20);
                    }
                    thisAmount += 300 * audience;
                    return thisAmount;
                case "horror":
                    thisAmount = 15000;
                    if (audience > 10)
                    {
                        thisAmount += 5000 + 500 * (audience - 10);
                    }
                    return thisAmount;
                default:
                    throw new Exception("Unknown type: " + type);
            }
        }

        public int AddCredit(string type, int audience)
        {
            int volumeCredits = 0;

            // add volume credits
            volumeCredits += Math.Max(audience - 30, 0);

            // add extra credit for every five comedy attendees
            if ("comedy" == type) volumeCredits += audience / 5;

            //add extra credit for every one horror attendee
            if ("horror" == type) volumeCredits += audience / 1;

            return volumeCredits;
        }
    }
}
