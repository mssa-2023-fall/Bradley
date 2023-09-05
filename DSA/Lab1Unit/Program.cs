using System.Runtime.CompilerServices;

namespace Kitchen
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Kitchen! What Protein do you want? Press enter to Continue");
            while (Console.ReadLine() != "exit")
            {
                Console.WriteLine("Welcome to Kitchen! What Protein do you want?");
                Console.WriteLine("We have beef, tofu, pepperoni or exit to leave");

                string proteinChoices = Console.ReadLine();
                string choice = proteinChoices.ToLower();

                switch (choice)
                {
                    case "beef":
                        Console.WriteLine("Great choice");
                        break;
                    case "tofu":
                        Console.WriteLine("Ok sure");
                        break;
                    case "pepperoni":
                        Console.WriteLine("Why not I Guess");
                        break;
                    default:
                        Console.WriteLine("You must not have seen our menu try again.");
                        break;
                }
            }
        }
    }
}