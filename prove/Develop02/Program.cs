using System;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        // NOTE: to exceed the requirements I created a "streak" attribute to
        // the journal class. Basically every day in a row you write in the
        // journal, your streak goes up by one. If you miss a day the 
        // streak goes to zero.;
        // NOTE: I didn't finish the exceed requirement.

        // initializing journal class;
        Journal journal1 = new Journal();

        //initializing list of prompts from file;
        List<string> promptList = new List<string>();
        string promptFile = "prompts.txt";
        string[] prompts = System.IO.File.ReadAllLines(promptFile);
        foreach(string line in prompts)
        {
            promptList.Add(line);
        }
        
        // initializing main menu
        Menu mainMenu = new Menu();
        mainMenu._options.Add("1. Write");
        mainMenu._options.Add("2. Display");
        mainMenu._options.Add("3. Load");
        mainMenu._options.Add("4. Save");
        mainMenu._options.Add("5. Quit");

        // user choosing option;
        bool x = true;
        while (x)
        {
        Console.WriteLine();
        mainMenu.DisplayOptions();
        Console.Write(">> ");
        try
        {
            int choice = int.Parse(Console.ReadLine());

            // quitting if you choose the last option of the list;
            if (choice == mainMenu._options.Count())
            {
                Console.WriteLine("Quitting...");
                x = false;
            }
            try
            {
                // this line is just for the try except argumentoutofrange exception;
                string menuChoice = mainMenu._options[choice-1];
                if (choice == 1)
                {
                    // Write;
                    Entry entry = new Entry();
                    // generating random prompt from the list to answer;
                    Random rnd = new Random();
                    int indx = rnd.Next(0,promptList.Count);
                    entry._prompt = promptList[indx];

                    // user can answer the prompt, and it get's saved to the journalEntries list.
                    Console.WriteLine(entry._prompt);
                    Console.Write(">> ");
                    entry._answer = Console.ReadLine();
                    entry._date = entry._currentTime.ToShortDateString();
                    entry._entry = $"{entry._date} {entry._prompt} {entry._answer}";
                    journal1._entries.Add(entry._entry);

                    // check if you have a streak;



                }
                else if (choice == 2)
                {
                    // Display
                    if (journal1._entries.Count() == 0)
                    {
                        Console.WriteLine("No journal entries currently loaded.");
                    }
                    else
                    {
                    for (int i=0; i < journal1._entries.Count(); i++)
                    {
                        Console.WriteLine(journal1._entries[i]);
                    }
                    }
                    if (journal1._fileName != "")
                    {
                        Console.WriteLine($"File loaded: {journal1._fileName}");
                    }
                }
                else if (choice == 3)
                {
                    // Load
                    Console.WriteLine("What file would you like to load from? (Please include the .txt in your answer.)");
                    string file = Console.ReadLine();
                    journal1._entries.Clear();
                    journal1._fileName = file;
                    string[] lines = System.IO.File.ReadAllLines(file);
                    foreach(string line in lines)
                    {
                        journal1._entries.Add(line);
                    }
                    Console.WriteLine("Successfully loaded.");
                }
                else if (choice == 4)
                {
                    // Save
                    // what this does is writes the journal list into the file.
                    // if the filename doesn't exist, it will create a new file.
                    // if the filename does exist, it will overwrite what's in it.
                    if (journal1._fileName == "")
                    {
                        Console.WriteLine("What filename would you like for your journal? (Please write .txt at the end)");
                        journal1._fileName = Console.ReadLine();
                    }
                    
                    if (journal1._entries.Count() == 0)
                    {
                        Console.WriteLine("Nothing to save. Please write some entries first.");
                    }
                    else
                    {
                    using (StreamWriter outputFile = new StreamWriter(journal1._fileName))
                    {
                        for (int i=0; i<journal1._entries.Count(); i++)
                        {
                            outputFile.WriteLine(journal1._entries[i]);
                        }
                    }
                    Console.WriteLine("Successfully Saved.");
                    }
                    
                }

            }

            // making sure the choice is in the menu list
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Please choose a number 1 through {mainMenu._options.Count()}.");
            }
        }

        // making sure the choice is a number;
        catch (FormatException)
        {
            Console.WriteLine("Please enter a number.");
        }
        }
        





    }
}