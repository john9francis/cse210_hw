using System;

class Program
{
    static void Main(string[] args)
    {
        // creating and setting up verses;
        Verse verse1 = new Verse();
        verse1.SetVerse("I, Nephi, having been aborn of bgoodly cparents, therefore I was dtaught somewhat in all the learning of my father; and having seen many eafflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a frecord of my proceedings in my days.");
        Verse verse2 = new Verse();
        verse2.SetVerse("Yea, I make a record in the alanguage of my father, which consists of the learning of the Jews and the language of the Egyptians.");
        Verse verse3 = new Verse();
        verse3.SetVerse("And I know that the record which I make is atrue; and I make it with mine own hand; and I make it according to my knowledge.");

        // adding verse to our scripture;
        Scripture s1 = new Scripture();
        s1.SetScriptureVerse(verse1,1);
        s1.SetScriptureVerse(verse2,2);
        s1.SetScriptureVerse(verse3,3);
        s1.SetScriptureReference("1 Nephi", 1, 1,3);

        bool x = true;
        while (x)
        {
            Console.Clear();
            Console.WriteLine(s1.GetFullScripture());
            Console.Write("Type \"Q\" to quit: ");
            string entry = Console.ReadLine();
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
}