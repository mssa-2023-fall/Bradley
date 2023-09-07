using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;



namespace GroceryStore
{
    class program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, decimal> productAndPrice = new Dictionary<string, decimal>()
            {
                {"apple", 1.99m },
                {"banana", 2.49m },
                {"watermelon", 3.99m },
                {"peach", 1.29m }
            };
            #region Initializing Variables
            decimal apple = 1.99m;
            decimal banana = 2.49m;
            decimal watermelon = 3.99m;
            decimal peach = 1.29m;

            decimal totalPrice = 0m;
            int totalItems = 1;
            int totalApples = 0;
            int totalBananas = 0;
            int totalWatermelons = 0;
            int totalPeach = 0;
            #endregion

            #region Menu Screen
            Console.WriteLine("Welcome to the Fresh Market!");
            Console.WriteLine("We have:");
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("Apple     |       Banana");
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("Peach     |   Watermelon");
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("When finished enter 'done'");
            Console.WriteLine();
            Console.WriteLine("Enter the items you want:");
            #endregion

            List<string> itemList = new List<string>();

            #region WhileLoop, IfStatements, Switch
            while (true)
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine().ToLower();
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine($"You scanned, {itemName} now you have a total of {totalItems} items in your cart.");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("OK what else?");

                if (itemName == "done")
                {
                    break; 
                }
                
                if(productAndPrice.ContainsKey(itemName))
                {
                    itemList.Add(itemName);
                    totalPrice += productAndPrice[itemName];
                    totalItems++;
                }
                else
                {
                    Console.WriteLine("What is this? Enter again.");
                }
                


                #region SwitchCase
                /* 
                 switch (itemName)
                 {
                     case "apple":
                         totalPrice += apple;
                         totalItems++;
                         totalApples++;
                         break;
                     case "banana":
                         totalPrice += banana;
                         totalItems++;
                         totalBananas++;
                         break;
                     case "watermelon":
                         totalPrice += watermelon;
                         totalItems++;
                         totalWatermelons++;
                         break;
                      case "peach":
                         totalPrice += peach;
                         totalItems++;
                         totalPeach++;
                         break;
                     default:
                         Console.WriteLine("Item not recognized. Please try again.");
                         break;
                 }
                */
                #endregion
            }
            #endregion

            #region StringBuilderOld
            /*
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("Receipt:");
            receipt.AppendLine("---------");

            receipt.AppendLine(totalApples.ToString("0") + " apples at: $" + apple.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalBananas.ToString("0") + " bananas at: $" + banana.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalWatermelons.ToString("0") + " watermelons at: $" + watermelon.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalPeach.ToString("0") + " peaches at: $" + peach.ToString("0.00") + " a piece.");

            receipt.AppendLine("---------");
            receipt.AppendLine("Total items purchased: " + totalItems.ToString("0") + " Total: $" + totalPrice.ToString("0.00"));
            */
            #endregion

            #region StringBuilderNew

            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("- - - - - - - - - - - - - ");
            receipt.Append(" ");

            foreach(string item in itemList) 
            {
                receipt.Append($"\n {item}: {productAndPrice[item]:0.00} dollars");
            }
            receipt.AppendLine("\n- - - - - - - - - - - - - ");
            receipt.AppendLine($"Total: ${totalPrice:0.00}");
            #endregion

            Console.WriteLine(receipt.ToString());

            Console.WriteLine("Thanks for shopping with us!");
        }
    }
}





