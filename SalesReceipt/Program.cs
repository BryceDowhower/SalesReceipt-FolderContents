//Bryce Dowhower
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReceipt
{
    class Program
    {
        /*
         * You will be creating an application to help our sales associates sell our main products, cogs and gears.  
         * Cogs have a whole sale price of $79.99 and gears have a whole sale price of $250.00.  When our sales associates 
         * are selling to our customers on the floor, we have a standard 15% markup on our wholesale price for our sales price. 
         * However, if the customer purchases more than 10 of either item or a combined quantity of 16 items we only markup the items by 12.5%.  
         * On top of this, the sales tax for all sales is 8.9%.
         * 
         * Create a console application that will prompt the sales associate for the number of cogs, the number of gears 
         * as well as their Customer ID for a sales order.  Once the user has input all of the data needed,
         * create a new instance of the Receipt (or a new Receipt object), call the PrintReceipt method on the object 
         * and then store it in some sort of collection.  Then you should ask if there is another order that needs to be
         * placed and repeat the process of order entry.
         * 
         * After all orders are entered, give the user options to either print all receipts based off of a CustomerID, print all receipts for 
         * the day, or print the receipt for the sale that had the highest total.  Keep prompting the user to see if they would like to perform 
         * another function until they indicate that they do not
         */
        const double CogsWhole = 79.99, GearsWhole = 250;
        const double SalesTax = .089;
       

        static void Main(string[] args)
        {
            List<Receipt> Receipts = new List<Receipt>();
            int x = 0;
            int AmountCogs, AmountGears,CusID;
            while (x == 0)
            {

                DateTime saledate = DateTime.Now;
                Console.WriteLine("What is your Customer ID?");
                Console.Write("Customer ID Entry: ");
                CusID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many cogs would you like to buy in this sales order?");
                Console.Write("Cogs to purchase: ");
                AmountCogs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("And how many gears would you like?");
                Console.Write("Gears to purchase: ");
                AmountGears = Convert.ToInt32(Console.ReadLine());
            
                Receipt NewReceipt = new Receipt(CusID, AmountCogs, AmountGears, saledate, SalesTax, CogsWhole, GearsWhole);
                NewReceipt.PrintReceipt();
                Receipts.Add(NewReceipt);
 
                 //Then you should ask if there is another order that needs to be placed and repeat the process of order entry.
                 Console.WriteLine("Is there another order that needs to be placed?");
                 string answer = Console.ReadLine().ToLower();
                 Console.WriteLine();
                 if (answer == "no" )
                 {
                     x = 1;
                 }
            }
            /*
             * After all orders are entered, give the user options to either print all receipts based off of a CustomerID, 
             * print all receipts for the day, or print the receipt for the sale that had the highest total.
             * Keep prompting the user to see if they would like to perform another function until they indicate that they do not.
             */
            while (x == 1)
            {
                Console.WriteLine();
                Console.WriteLine("-----Receipt options-----");
                Console.WriteLine("Please select the number that matches the receipt option you would like to display:");
                Console.WriteLine("(1) Print all receipts based on customerID");
                Console.WriteLine("(2) Print all receipts for the day");
                Console.WriteLine("(3) Print the receipt for the sale that has the highest total sale");
                Console.WriteLine();
                Console.Write("User Selection: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine($"--------Receipts for Customer ID {choice}--------");
                    List<Receipt> IDList = new List<Receipt>();
                    Console.WriteLine("Please enter in the CustomerID you would like to search for.");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    foreach (var receipt in Receipts)
                    {
                        if(receipt.CustomerID == ID)
                        {
                            IDList.Add(receipt);
                        }
                    }
                    foreach (var receipt in IDList)
                    {
                        receipt.PrintReceipt();
                    }
                    Console.WriteLine("-------------------------");
                }
                else if (choice ==2)
                {

                    Console.WriteLine($"--------Receipts for today--------");
                    List<Receipt> DateList = new List<Receipt>();
                    string now = DateTime.Now.ToString("d");                    
                    foreach (var receipt in Receipts)
                    {
                        string receiptdate = receipt.SaleDate.ToString("d");
                        if (receiptdate == now)
                        {
                            DateList.Add(receipt);
                        }
                    } 
                    foreach (var receipt in DateList)
                    {
                        receipt.PrintReceipt();
                    }
                    Console.WriteLine("-------------------------");
                }
                else if (choice == 3)
                {
                    Console.WriteLine($"--------Receipt for sale with highest sale total --------");
                    double max = 0;
                    foreach (var receipt in Receipts)
                    {
                        double total = receipt.CalculateTotal();
                        if (total > max)
                        {
                            max = total;
                        }
                    }
                    foreach (var receipt in Receipts)
                    {
                        double maxtotal = receipt.CalculateTotal();
                        if (maxtotal == max)
                        {
                            receipt.PrintReceipt();
                        }
                    }
                    Console.WriteLine("-------------------------");
                }
                else
                {
                    Console.WriteLine("Sorry, the option you selected is not one of the options.");
                }
                Console.WriteLine("Would you like to preform a new receipt search?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "no")
                {
                    x = 0;
                }
            }

            Console.ReadKey();

        }
         


    }
}
