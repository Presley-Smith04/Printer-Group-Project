using System;
using System.Collections.Generic;
using System.Net.Quic;


//class to represent doc to print
class Document
{
    //doc name
    public string Name { get; set; }
    //true if doc is in color
    public bool IsColor { get; set; }
    //num of pages
    public int PageCount { get; set; }
    //double sided?
    public bool IsDoubleSided { get; set; }

    //constructor for properties above
    public Document(string name, bool isColor, int pageCount, bool isDoubleSided)
    {
        Name = name;
        IsColor = isColor;
        PageCount = pageCount;
        IsDoubleSided = isDoubleSided;
    }

    //override toString for the print 
    public override string ToString()
    {
        string colorMode = IsColor ? "Color" : "Black & White";
        string sides = IsDoubleSided ? "Double-Sided" : "Single-Sided";
        return $"{Name} ({colorMode}, {PageCount} pages, {sides})";
    }
}



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
        - color
        - black and white
        - how many pages to print
        - single or double sided
        - change queue order
        - printer change
        - printer list with a printer object / class
        - queue manipulation (previous / next)
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