# Printer

## Team
- Max Sigrest: Testing 
- Presley Smith: Team Lead
- Saavan Tandon: Error Handling 
- Kaiden Terrana: Testing & Documentation

Made for IGME 201

## Specs
**Print Queue Simulation (Queue):**
- Create a `Queue<string>` to represent a print queue.
- Allow the user to add documents to the queue.
- Each time a document is "printed," it should be removed from the queue.
- Display the queue status after each operation.

## How to use
### To run the project: 
1. Clone this repository 
2. Open the solution & files in Visual Studio 
3. Run with or without debugging 

### Running the project: 
1. To add documents to the queue: 
    1. When you reach the menu, enter `a`
    2. It will then prompt you for the following: 
        - Document name 
        - If it is a Color or Black & White document
        - Number of pages
        - If it is Double or Single Sided 
2. To print documents:
    1. When you reach the menu, enter `p`
    2. It will then print any documents that may be in the queue
3. To view print queue: 
    1. When you reach the menu, enter `v`
    2. It will then show you the name of each document in the queue, alongside the details for each document 
4. To change printers: 
    1. When you reach the menu, enter `c`
    2. It will then show you a list of available printers to select from
        - Select the number you wish to change to
5. To reorder document queue
    1. When you reach the menu, enter `r`
    2. If you have enough documents in the queue, it will show you a preview of the current queue
    3. Enter the document number you would like to move
    4. Then enter the position you would like to move the document to (starting from 1)
6. To quit the program
    1. When you reach the menu, enter `q`
