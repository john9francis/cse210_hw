using System;

class Program
/*
This is a scripture memorizing program. The default program has one scripture to memorize,
and an option for the user to enter more scriptures. 
*/
{
    static void Main(string[] args)
    {
        // creating a list to store a couple of scriptures if we want to;
        List<Scripture> scriptureList = new List<Scripture>();

        // creating and setting up verses;
        Verse verse1 = new Verse();
        verse1.SetVerse("I, Nephi, having been aborn of bgoodly cparents, therefore I was dtaught somewhat in all the learning of my father; and having seen many eafflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a frecord of my proceedings in my days.");
        Verse verse2 = new Verse();
        verse2.SetVerse("Yea, I make a record in the alanguage of my father, which consists of the learning of the Jews and the language of the Egyptians.");
        Verse verse3 = new Verse();
        verse3.SetVerse("And I know that the record which I make is atrue; and I make it with mine own hand; and I make it according to my knowledge.");

        // adding verses to our scripture;
        Scripture s1 = new Scripture();
        s1.SetScriptureVerse(verse1,1);
        s1.SetScriptureVerse(verse2,2);
        s1.SetScriptureVerse(verse3,3);
        s1.SetScriptureReference("1 Nephi", 1, 1,3);
        scriptureList.Add(s1);

        // Functions ------------------------------------------------------------;
        Scripture CreateNewScripture()
        {
            Scripture s = new Scripture();

            // input the reference;
            Console.Write("Please enter the book of scripture: ");
            string book = Console.ReadLine();
            Console.Write("Please enter the chapter: ");
            int chapter = int.Parse(Console.ReadLine());
            
            // getting verse numbers;
            string verseNumber = "not blank";
            List<string> verseNumbers = new List<string>();
            while(verseNumber != "")
            {
                Console.Write("Please enter verse numbers one at a time. When you're finished entering verse numbers, press enter: ");
                verseNumber = Console.ReadLine();
                if (verseNumber != "")
                {
                    verseNumbers.Add(verseNumber);
                }
            }

            // adding verse numbers to the reference;
            int startVerse = int.Parse(verseNumbers[0]);
            int endVerse = 0;
            if (verseNumbers.Count() > 1)
            {
                endVerse = int.Parse(verseNumbers[verseNumbers.Count()-1]);
            }

            // adding reference to the scripture object;
            s.SetScriptureReference(book, chapter, startVerse, endVerse);
            
            // getting actual verses;
            Console.WriteLine("Please enter each verse, and then press enter.");
            for (int i=int.Parse(verseNumbers[0]); i<verseNumbers.Count() + int.Parse(verseNumbers[0]); i++)
            {
                Console.Write($"Verse {i}: ");
                string verse = Console.ReadLine();
                Verse v = new Verse(verse); // creates a new verse with this string as the verse.
                s.SetScriptureVerse(v,i);
            }

            return s;
        }

        void MemorizeScripture(Scripture s1)
        {
            bool x = true;
            // x = false; //FOR TESTING PURPOSES;
            while (x)
            {
                Console.Clear();
                Console.WriteLine(s1.GetFullScripture());
                Console.Write("Type \"Q\" to quit: ");
                string entry = Console.ReadLine();

                // quit if all the words are dashed;
                int undashed = 0;
                foreach (Verse verse in s1.GetVerseList())
                {
                    undashed += verse.GetUndashedWords();
                    if (undashed == 0)
                    {
                        x = false;
                    }
                }

                if (entry == "q" || entry == "Q")
                {
                    x = false;
                }
                else
                {
                    s1.DashStuff();
                }
            }
            }

        // PROGRAM STARTS -------------------------------------------------------;
        bool program = true;
        while(program)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the scripture memorizing program.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("To memorize a random scripture, press \"M.\"");
            Console.WriteLine("To see the list of scriptures in the scripture list, press \"L.\"");
            Console.WriteLine("To add a new scripture to the list, press \"A.\"");
            Console.WriteLine("To quit, press \"Q.\"");
            string selection = Console.ReadLine();
            if (selection == "M" || selection == "m")
            {
                // choose random scripture from the list;
                Random rnd = new Random();
                int index = rnd.Next(0, scriptureList.Count());
                Scripture s = scriptureList[index];
                MemorizeScripture(s);
                Console.WriteLine("Press enter to go back to the menu.");
                Console.ReadLine();
            }
            else if (selection == "L" || selection == "l")
            {
                Console.Clear();
                Console.WriteLine("Scripture list:");
                Console.WriteLine();
                foreach(Scripture s in scriptureList)
                {
                    Console.WriteLine(s.GetScriptureReference());
                    
                }
                Console.WriteLine("(Press enter to go back to the menu)");
                Console.ReadLine();
            }
            else if (selection == "A" || selection == "a")
            {
                Scripture s = CreateNewScripture();
                scriptureList.Add(s);
                Console.WriteLine("Scripture added. Press enter to return to main menu.");
                Console.ReadLine();
            }
            else if (selection == "Q" || selection == "q")
            {
                program = false;
            }
            else
            {
                Console.WriteLine("Sorry, invalid choice. Press enter to make another choice.");
                Console.ReadLine();
            }
        }
        

        


    }
}