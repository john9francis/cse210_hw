using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        // Program;
        // initializing stuff;
        List<Scripture> scriptures = new List<Scripture>();
        Scripture s1 = new Scripture();
        s1.SetReference("John 2",1,3);
        
        // getting the verses in the scripture
        List<string> verses = new List<string>();
        verses.Add("And the third day there was a marriage in Cana of Galilee; and the mother of Jesus was there:");
        verses.Add("And both Jesus was called, and his disciples, to the marriage.");
        verses.Add("And when they wanted wine, the mother of Jesus saith unto him, They have no wine.");

        for (int i=0; i<verses.Count(); i++)
        {
            Verse v = new Verse();
            v.SetVerse(verses[i]);
            s1.SetScripture(i+1,v);
        }

        bool x = true;
        while (x)
        {
            //Console.Clear();
            Console.WriteLine(s1.GetScripture());
            Console.Write("Type \"Q\" to quit: ");
            string entry = Console.ReadLine();
            if (entry == "q" || entry == "Q")
            {
                x = false;
            }

            // dash some words;
            s1.DashStuff();
            
        }
        
        s1.DisplayVerseList();
        */

        // creating and setting up a verse;
        Verse verse1 = new Verse();
        verse1.SetVerse("I nephi, having been born of goodly parents, therefore having a knowledge...");
        verse1.CreateWordList();

        bool x = true;
        while (x == true)
        {
        Console.Clear();
        {
            // display the verse;
            foreach (int i in Enumerable.Range(0,verse1._verseWords.Count()))
            {
                Console.Write(verse1.GetVWord(i));
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("Type \"Q\" to quit");
            string entry = Console.ReadLine();

            // let the user quit;
            if (entry == "q" || entry == "Q")
            {
                x = false;
            }
            else if (verse1.GetUndashedWords() == 0)
            {
                x = false;
            }

            // dash some random words;
            verse1.DashRandomWords();
        }
        }

        

    }
}