using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReceipt
{
    class Receipt
    {
        public int CustomerID { get; set; }
        public int CogQuantity { get; set; }
        public int GearQuantity { get; set; }
        public DateTime SaleDate { get;}
        private double SalesTaxPercent { get; set; }
        private double CogPrice { get; set; }
        private double GearPrice { get; set; }

        public Receipt( )
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Now;
            SalesTaxPercent = 0;
            CogPrice = 0;
            GearPrice = 0;
        }

        public Receipt(int custid, int cogquant, int gearquant, DateTime saledate, double salestaxperc, double cogprice, double gearprice)
        {
            CustomerID = custid;
            CogQuantity = cogquant;
            GearQuantity = gearquant;
            SaleDate = saledate;
            SalesTaxPercent = salestaxperc;
            CogPrice = cogprice;
            GearPrice = gearprice;            
        }
        /*
            The CalculateTotal method will tabulate the final total for the sale.  To do this, you will need to call the
            CalculateNetAmount method and the CalculateTaxAmount method to get the net amount and the tax amount. 
            You will then add the tax amount from the net amount and return that value.
        */
        public double CalculateTotal()
        {
            double netamount = CalculateNetAmount();
            double taxvalue = CalculateTaxAmount();
            double totalcost = netamount + taxvalue;
            return totalcost;
        }
        /*
         *  The PrintReceipt method will write to the console all the details about the sale in an easy to read format. 
         *  Not all on just one line, must include what the value represents (e.g. not just 5 but # of Cogs : 5).  Format all values appropriately. 
         */
        double Overallgearcost, Overallcogcost,Discount,receiptmarkup;
        public void PrintReceipt()
        {
            double totalamount = CalculateTotal();
            double taxtotal = CalculateTaxAmount();

            double netamount = CalculateNetAmount();

            Console.WriteLine();
            Console.WriteLine("Reciept:");
            Console.WriteLine($"CustomerID: {CustomerID}");
            Console.WriteLine($"Amount of Cogs Purchased: {CogQuantity}         Cost: {Overallcogcost.ToString("C2")}");
            Console.WriteLine($"Amount of Gears Purchased: {GearQuantity}         Cost: {Overallgearcost.ToString("C2")}");
            Console.WriteLine($"Net amount for the above items:           {netamount.ToString("C2")}");
            Console.WriteLine($"Discount percent: {receiptmarkup.ToString("P2")}");
            Console.WriteLine($"Amount Saved: {Discount.ToString("C2")}");
            Console.WriteLine($"Sales Tax: {taxtotal.ToString("C2")}");
            Console.WriteLine($"Final Purchase total: {totalamount.ToString("C2")}");
            Console.WriteLine();

        }
        
        /*
         *  The CalculateTaxAmount method will tabulate the total tax for the sale.  To do this, you will need to call the
         *  CalculateNetAmount and then multiple by your class (instance) variable, SalesTaxPercent.
         *  You will then return the total tax for the sale (Note: this should be a positive value).
         */
        private double CalculateTaxAmount()
        {
            double netamount = CalculateNetAmount();
            double taxvalue = netamount * SalesTaxPercent;

            return taxvalue;
        }
        /*
         *  The CalculateNetAmount method will tabulate the net price of the sale.  You will need to figure out what markup
         *  percent we need to add to our base unit prices for the Cog and Gears based upon the number purchased. 
         *  Once you do this, the formula for to calculate the netAmount is:
         *  netAmount = CogQuantity * Cog Price with markup + GearQuantity * Gear Price with markup
         */
        private double CalculateNetAmount()
        {
            const double RegMarkup = .15, SpecialMarkup = .125;
            double markup = 0;
            if (16 <= GearQuantity + CogQuantity)
            {
                markup = SpecialMarkup;
            }
            else if (10 <= GearQuantity)
            {
                markup = SpecialMarkup;
            }
            else if (10 <= CogQuantity)
            {
                markup = SpecialMarkup;
            }
            else
            {
                markup = RegMarkup;
            }
            double gearsmarkup = GearPrice * markup;
            double cogsmarkup = CogPrice  * markup;
            double totalgearcost = (gearsmarkup + GearPrice) * GearQuantity;
            double totalcogscost = (cogsmarkup + CogPrice) * CogQuantity;
            double netamount = totalcogscost + totalgearcost;
            {
                //Cheeky stuff hidden here for the receipt output
                Overallgearcost = totalgearcost;
                Overallcogcost = totalcogscost;
                //------------discount calcs----------
                double geardiscount = (GearPrice * GearQuantity * RegMarkup) - (GearPrice * GearQuantity * markup);
                double cogsdiscount = (CogPrice * CogQuantity * RegMarkup) - (CogPrice * CogQuantity * markup);
                double totaldiscount = geardiscount + cogsdiscount;
                Discount = totaldiscount;
                receiptmarkup = markup;

            }
            return netamount;
        }




    }
}
