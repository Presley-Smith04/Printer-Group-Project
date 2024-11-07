using System;
using System.Collections.Generic;
using System.Net.Quic;

class Program
{
    static void Main()
    {
        // Print Queue
        Queue<string> printQueue = new Queue<string>();

        // Add documents to print queue
        printQueue.Enqueue("Document1");
        printQueue.Enqueue("Document2");
        printQueue.Enqueue("Document3");

        Console.WriteLine("Print Queue:");
        while (printQueue.Count > 0)
        {
            Console.WriteLine($"Printing: {printQueue.Dequeue()}");
        }

        // Browser History
        Stack<string> browserHistory = new Stack<string>();

        // Visit pages
        browserHistory.Push("Page1");
        browserHistory.Push("Page2");
        browserHistory.Push("Page3");

        Console.WriteLine("\nBrowser History:");
        while (browserHistory.Count > 0)
        {
            Console.WriteLine($"Going back to: {browserHistory.Pop()}");
        }



        string userInput = "";

        /*other things to think of 
        - print
        - print suboptions
        - color
        - black and white
        - how many pages to print
        - single or double sided
        - change queue order
        - printer change
        - printer list with a printer object / class
        - queue manipulation (previous / next)
        - preview doc
        - number of physical pages available
        - amount of ink
        - cancel print
        - let user know about things (success / errors)
        - input detection and error handling
        */

        while(userInput != "q")
        {
            Console.WriteLine("What do you want to do");
            Console.WriteLine("Options: \n 'a' to add a document to the queue. \n 'p' to print all documents. \n ");
            userInput = Console.ReadLine();

            if (userInput == "q")
            {
                Console.WriteLine("Thanks for using");
            }
            else if (userInput == "a")
            {
                Console.WriteLine("Which document do you want to add to the print queue");
                string docName = Console.ReadLine();
            }
            else if (userInput == "p")
            {
                Console.WriteLine($"Printing: {printQueue.Dequeue()}");

                //print x
                while (printQueue.Count > 0)
                {
                    Console.WriteLine($"Printing: {printQueue.Dequeue()}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid input!");
            }
        }
    }
}