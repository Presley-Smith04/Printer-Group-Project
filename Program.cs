﻿using System;
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



//add printer class 
class Printer
{
    //printer name
    public string Name { get; set; }


    //constructor for printer name
    public Printer(string name)
    {
        Name = name;
    }

    //override toString function for printer identity
    public override string ToString() => Name;
}




//update program class to include everything and do these things;
/*
        -color
        - black and white
        - how many pages to print
        - single or double sided
        - change queue order
        - printer change
        - printer list with a printer object / class
        -queue manipulation(previous / next)
*/

class Program
{
    static void Main()
    {
        // Print Queue
        Queue<Document> printQueue = new Queue<Document>();


        //list of all printers
        List<Printer> printers = new List<Printer>
        {
            new Printer("Printer 1"),
            new Printer("Printer 2"),
            new Printer("Printer 3")
        };


        //default
        Printer selectedPrinter = printers[0];
        string userInput = "";
        Console.WriteLine("Welcome to the Printer!");



        //main loop
        while (userInput != "q")
        {
            //options
            Console.WriteLine("What do you want to do");
            Console.WriteLine("Options: ");
            Console.WriteLine("'a' - Add Document to the queue");
            Console.WriteLine("'p' - Print all Docs");
            Console.WriteLine("'v' - View Print Queue");
            Console.WriteLine("'c' - Change Printer");
            Console.WriteLine("'r' - Reorder Queue");
            Console.WriteLine("'q' - Quit");
            userInput = Console.ReadLine();

            //use switch cases instead of loops just for an easier time
            switch (userInput)
            {
                case "a":

                    //questions
                    Console.Write("Enter Document Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Color? (yes/no): ");
                    bool isColor = Console.ReadLine().ToLower() == "yes";

                    //ask for page count and check if it's valid so program doesn't break
                    int pageCount = 0;
                    bool validPageCount = false;
                    while (!validPageCount)
                    {
                        Console.Write("How many pages?: ");
                        validPageCount = int.TryParse(Console.ReadLine(), out pageCount);//make sure it's an integer
                        if (!validPageCount)
                            Console.WriteLine("Invalid input. Please enter a valid number for page count.");
                    }

                    Console.Write("Double Sided? (yes/no): ");
                    bool isDoubleSided = Console.ReadLine().ToLower() == "yes";

                    //new document and queue
                    printQueue.Enqueue(new Document(name, isColor, pageCount, isDoubleSided));
                    Console.WriteLine("Document added Sucessfully!");
                    break;


                case "p":
                    //print all documents
                    if (printQueue.Count == 0)
                    {
                        Console.WriteLine("The Queue is empty");
                    }
                    else
                    {
                        //dequeue and print all
                        Console.WriteLine($"Printing on {selectedPrinter.Name}");
                        while (printQueue.Count > 0)
                        {
                            Console.WriteLine($"Printing: {printQueue.Dequeue()}");
                        }
                    }
                    break;

                case "v":
                    //view queue docs
                    if (printQueue.Count == 0)
                    {
                        Console.WriteLine("The Queue is Empty");
                    }
                    else
                    {
                        Console.WriteLine("Print Queue: ");
                        foreach (var doc in printQueue)
                        {
                            Console.WriteLine(doc);
                        }
                    }
                    break;


                case "c":
                    //printer change
                    Console.WriteLine("Available Printers: ");
                    for (int i = 0; i < printers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {printers[i]}");
                    }

                    Console.Write("Select a new printer by Number: ");
                    string printerInput = Console.ReadLine();
                    int printerIndex = -1;
                    
                    if (int.TryParse(printerInput, out printerIndex) && printerIndex >= 1 && printerIndex <= printers.Count)//check if the given index is a valid int
                    {
                        selectedPrinter = printers[printerIndex-1];//for 1-based index
                        Console.WriteLine($"Printer changed!, New Printer is {selectedPrinter.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Printer Selection...");
                    }
                    break;

                case "r":
                    //reorder queue
                    if (printQueue.Count > 1)
                    {
                        Console.WriteLine("Current Queue:");
                        var docs = new List<Document>(printQueue);
                        //store docs in a list for reordering
                        for (int i = 0; i < docs.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {docs[i]}");
                        }


                        Console.Write("Enter The Position of the Doc to move: ");
                        int fromIndex = int.Parse(Console.ReadLine()) - 1;

                        Console.Write("Enter New Position: ");
                        int toIndex = int.Parse(Console.ReadLine()) - 1;

                        

                        //validate list order
                        if (fromIndex >= 0 && fromIndex < docs.Count && toIndex >= 0 && toIndex < docs.Count)
                        {
                            if(fromIndex != toIndex)//as long as they're not changing it to the same index
                            {
                                var doc = docs[fromIndex];
                                docs.RemoveAt(fromIndex);
                                docs.Insert(toIndex, doc);

                                //clear and fill the queue with new doc ofder
                                printQueue.Clear();
                                foreach (var d in docs)
                                {
                                    printQueue.Enqueue(d);
                                }
                                Console.WriteLine("Queue updated!");
                            }
                            else//if they're changing to the same index, skip the extra steps
                            {
                                Console.WriteLine("Your document is already in the right position! No changs needed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Positions Entered...");

                        }

                    }
                    else
                    {
                        Console.WriteLine("Not Enough Documents to Reorder...");
                    }
                    break;

                case "q":
                    //quit
                    Console.WriteLine("Thank you for using the Print Manager!!!!");
                    break;


                default:
                    //handle invalid inputs
                    Console.WriteLine("Invalid Input...Try Again...");
                    break;


            }
        }
    }
}
