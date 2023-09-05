using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define the root directory
        string rootDirectory = @"C:\Program Files";

        // Check if the root directory exists
        if (!Directory.Exists(rootDirectory))
        {
            Console.WriteLine("Root directory does not exist.");
            return;
        }

        Console.WriteLine("Select a branch to explore:");

        // List subdirectories in the root directory
        string[] subDirectories = Directory.GetDirectories(rootDirectory);

        for (int i = 0; i < subDirectories.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(subDirectories[i])}");
        }

        Console.Write("Enter the number of the branch to explore (0 to exit): ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= subDirectories.Length)
        {
            string selectedBranch = subDirectories[choice - 1];
            ExploreBranch(selectedBranch);
        }
        else if (choice == 0)
        {
            Console.WriteLine("Exiting the program.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    static void ExploreBranch(string branchPath)
    {
        Console.WriteLine($"Exploring branch: {branchPath}");

        // You can list and manipulate files and subdirectories within the selected branch here.
        // For example, you can use Directory.GetDirectories() and Directory.GetFiles() to list subdirectories and files.
    }
}
