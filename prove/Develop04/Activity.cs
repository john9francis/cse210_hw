public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected List<string> _animationList; 
    protected List<string> _prompts;
    protected List<string> _questions;


    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
        //creating the basic animation list;
        _animationList = new List<string>();
        _animationList.Add("|");
        _animationList.Add("/");
        _animationList.Add("-");
        _animationList.Add("\\");

    }

    protected void SetDuration()
    {
        Console.Write("How many seconds do you want to spend on this activity? ");
        _duration = int.Parse(Console.ReadLine());

    }
    protected void ShowBasicAnimation1()
    // shows animation for 5 seconds;
    {
        DateTime _now = DateTime.Now;
        DateTime _range = _now.AddSeconds(10);

        while(_now < _range)
        {
            _now = DateTime.Now;
            Console.Write("+");

            Thread.Sleep(500);

            Console.Write("\b \b"); // Erase the + character
            Console.Write("-"); // Replace it with the - character

            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
    protected void ShowAnimation(List<string> _animationList, int repeats=1)
    // takes a list of characters and creates them into an animation;
    {
        for (int k=0; k<repeats; k++)
        {
            for (int i=0; i<_animationList.Count(); i++)
            {
                Console.Write(_animationList[i]);
                Thread.Sleep(200);
                int _length = _animationList[i].Length;
                for (int j=0; j<_length; j++)
                {
                    Console.Write("\b");
                }
            }
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i= seconds; i>=0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                //count how many spaces to delete;
                string num = $"{i}";
                int len = num.Length;
                for (int j = 0; j<len; j++)
                {
                    Console.Write("\b");
                }
                
            }   
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"{_description}");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        for (int i=0; i<3; i++)
        {
        ShowAnimation(_animationList);
        }
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job.");
        ShowAnimation(_animationList);
        Console.WriteLine($"You have finished the {_name} activity for {_duration} seconds.");
        ShowAnimation(_animationList);
    }
}