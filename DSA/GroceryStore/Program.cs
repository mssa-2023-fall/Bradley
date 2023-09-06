using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GroceryStore
{
    class program
    {
        public static void Main(string[] args)
        {
            /*
            Dictionary<string, decimal> productAndPrice = new Dictionary<string, decimal>()
            {
                {"apple", 1.99m },
                {"banana", 2.49m },
                {"watermelon", 3.99m },
                {"peach", 1.29m }
            };
            */
            decimal apple = 1.99m;
            decimal banana = 2.49m;
            decimal watermelon = 3.99m;
            decimal peach = 1.29m;

            decimal totalPrice = 0m;
            int totalItems = 0;
            int totalApples = 0;
            int totalBananas = 0;
            int totalWatermelons = 0;
            int totalPeach = 0;

            Console.WriteLine("Welcome to the Grocery Store!");
            Console.WriteLine("Enter the items you want to scan (e.g., 'apple', 'banana', 'watermelon', 'peach', or 'done' to finish):");

            List<string> itemList = new List<string>();

            while (true)
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine().ToLower();

                if (itemName == "done")
                {
                    break; // Exit the loop when 'done' is entered.
                }
                /*
                if(productAndPrice.ContainsKey(itemName))
                {
                    itemList += productAndPrice[]
                    totalPrice += productAndPrice[itemName];
                }
                */
                
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
            }

            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("Receipt:");
            receipt.AppendLine("---------");

            receipt.AppendLine(totalApples.ToString("0") + " apples at: $" + apple.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalBananas.ToString("0") + " bananas at: $" + banana.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalWatermelons.ToString("0") + " watermelons at: $" + watermelon.ToString("0.00") + " a piece.");
            receipt.AppendLine(totalPeach.ToString("0") + " peaches at: $" + peach.ToString("0.00") + " a piece.");

            receipt.AppendLine("---------");
            receipt.AppendLine("Total items purchased: " + totalItems.ToString("0") + " Total: $" + totalPrice.ToString("0.00"));

            Console.WriteLine(receipt.ToString());

            Console.WriteLine("Thank you for shopping with us!");
        }
     }
}