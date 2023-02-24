public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private string _startingMessage;
    private string _finishingMessage;
    private List<string> _testAnimationList; 
    private List<string> _breatheAnimationList; 


    public Activity()
    {
        _name = "";
        _description = "";
        _finishingMessage = "";
        _duration = 0;
        _startingMessage = "";
        _finishingMessage = "";
        //creating the test animation list;
        _testAnimationList = new List<string>();
        _testAnimationList.Add("/\\/\\/\\");
        _testAnimationList.Add("\\/\\/\\/");

            
        //creating the breathe animation list;
        _breatheAnimationList = new List<string>();
        _breatheAnimationList.Add("____`____");
        _breatheAnimationList.Add("___-`-___");
        _breatheAnimationList.Add("_--```--_");
        _breatheAnimationList.Add("--`````--");
        _breatheAnimationList.Add("--`````--");
        _breatheAnimationList.Add("-```````-");
        _breatheAnimationList.Add("`````````");

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
    protected void ShowAnimation(List<string> _animationList)
    // takes a list of characters and creates them into an animation;
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
    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine($"{_description}");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        List<string> l1 = _testAnimationList;
        ShowAnimation(_breatheAnimationList);
        ShowAnimation(_breatheAnimationList);
        ShowAnimation(_breatheAnimationList);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job.");
        ShowAnimation(_testAnimationList);
        Console.WriteLine($"You have finished the {_name} activity for {_duration} seconds.");
        ShowAnimation(_testAnimationList);
    }
}