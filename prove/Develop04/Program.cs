using System;

class Program
{
    static void Main(string[] args)
    {
        void Pause(int speed=200, int cycles = 3)
        /*Takes in speed of animation and cycles, Pauses to load and show an animation*/
        {
            for (int i=0; i<cycles; i++)
            {
                Console.Write("|");
                Thread.Sleep(speed);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(speed);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(speed);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(speed);
                Console.Write("\b \b");
            }

        }

        Menu m1 = new Menu();
        int choice = m1.DisplayMenu();
        try
        {
            string activity = m1.GetMenuOption(choice);
            Console.WriteLine($"You chose {activity}");
            Pause();
            if (activity == "Breathing Activity")
            {
                BreathingActivity ba = new BreathingActivity();
                ba.StartActivity();
                ba.Breathe();
                ba.EndActivity();
            }
            else if (activity == "Reflection Activity")
            {
                ReflectionActivity ra = new ReflectionActivity();
                ra.StartActivity();
                ra.Reflect();
                ra.EndActivity();
            }
            else if (activity == "Listing Activity")
            {
                ListingActivity la = new ListingActivity();
                la.StartActivity();
                la.List();
                la.EndActivity();
            }
            else
            {
                Console.WriteLine("Activity not found.");
            }

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid choice.");
            Pause();
        }
        
    }
}