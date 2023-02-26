public class ListingActivity: Activity
{
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    
        _animationList = new List<string>();
        _animationList.Add("     ");
        _animationList.Add("^    ");
        _animationList.Add("-    ");
        _animationList.Add("-^   ");
        _animationList.Add("--   ");
        _animationList.Add("--^  ");
        _animationList.Add("---  ");
        _animationList.Add("---^ ");
        _animationList.Add("---- ");
        _animationList.Add("----^");
        _animationList.Add("-----");


        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

    }

    public void List()
    {
        Console.Clear();

        Random rnd = new Random();
        int _i = rnd.Next(0, _prompts.Count());
        string _prompt = _prompts[_i];
        
        Console.WriteLine();
        Console.WriteLine(_prompt);
        Console.WriteLine();
        Console.Write("Think about this for a couple seconds and then get ready to list. ");
        Countdown(5);
        Console.WriteLine("\n");

        //Let the user list until the time runs out;
        // keep track of time;
        DateTime _startTime = DateTime.Now;
        DateTime _endTime = _startTime.AddSeconds(_duration);

        int _listEntriesCount = 0;

        bool time = true;
        while (time)
        {
            if (_listEntriesCount == 0)
            {
                Console.WriteLine("Start listing! ");
                Console.ReadLine();
                _listEntriesCount += 1;
            }
            else
            {
                Console.WriteLine("Keep going... ");
                Console.ReadLine();
                _listEntriesCount += 1;
            }

            DateTime _currentTime = DateTime.Now;
            if (_currentTime > _endTime)
            {
                time = false;
            }
        }

        Console.WriteLine($"You have listed {_listEntriesCount} things.");
        ShowAnimation(_animationList, 2);
    }
}