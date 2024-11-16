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
        while(userInput != "q")
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

                    //quetions
                    Console.Write("Enter Document Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Color? (yes/no): ");
                    bool isColor = Console.ReadLine().ToLower() == "yes";

                    Console.Write("How Many pages?: ");
                    int pageCount = int.Parse(Console.ReadLine());

                    Console.Write("Double Sided? (yes/no): ");
                    bool isDoubleSided = Console.ReadLine().ToLower() == "yes";

                    //new document and queue
                    printQueue.Enqueue(new Document(name, isColor, pageCount, isDoubleSided));
                    Console.WriteLine("Document added Sucessfully!");
                    break;


                case "p":
                    //print all documents
                    if(printQueue.Count == 0)
                    {
                        Console.WriteLine("The Queue is empty");
                    }
                    else
                    {
                        //dequeue and print all
                        Console.WriteLine($"Printing on {selectedPrinter.Name}");
                        while(printQueue.Count > 0)
                        {
                            Console.WriteLine($"Printing: {printQueue.Dequeue()}");
                        }
                    }
                    break;



        }
    }
}