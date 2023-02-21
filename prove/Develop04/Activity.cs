public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private string _startingMessage;
    private string _finishingMessage;
    private List<string> _testAnimationList; 

    public Activity()
    {
        _name = "";
        _description = "";
        _finishingMessage = "";
        _duration = 0;
        _startingMessage = "";
        _finishingMessage = "";
        _testAnimationList = new List<string>();
        _testAnimationList.Add("_____");
        _testAnimationList.Add("____/");
        _testAnimationList.Add("___/\\");
        _testAnimationList.Add("__/\\_");
        _testAnimationList.Add("_/\\__");
        _testAnimationList.Add("/\\___");
        _testAnimationList.Add("\\____");

    }

    protected void SetDuration()
    {
        Console.Write("How long do you want to spend on this activity? ");
        _duration = int.Parse(Console.ReadLine());

    }
    protected void ShowAnimation1()
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
    protected void ShowAnimation2(List<string> _animationList)
    // takes a list of characters and creates them into an animation;
    {
        for (int i=0; i<_animationList.Count(); i++)
        {
            Console.Write(_animationList[i]);
            Thread.Sleep(200);
            for (int j=0; j<5; j++)
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
        ShowAnimation2(_testAnimationList);
        ShowAnimation2(_testAnimationList);
        ShowAnimation2(_testAnimationList);

    }
}