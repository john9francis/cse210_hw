public class ReflectionActivity: Activity
{

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _animationList = new List<string>();
        _animationList.Add("(o_o )");
        _animationList.Add("(o_o )");
        _animationList.Add("(o_o )");
        _animationList.Add("(-_- )");
        _animationList.Add("(-_- )");
        _animationList.Add("(o_o )");

        // get the prompts and questions added in:
        _prompts = new List<string>();
        _questions = new List<string>();

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

    }

    public void Reflect()
    {
        Console.Clear();
        // keep track of time;
        DateTime _startTime = DateTime.Now;
        DateTime _endTime = _startTime.AddSeconds(_duration);

        Random _rnd = new Random();
        int _i = _rnd.Next(0,_prompts.Count()-1);
        string _prompt = _prompts[_i];

        Console.Write(_prompt);
        ShowAnimation(_animationList, 2);
        Console.WriteLine("\n");

        Console.Write("Take a minute to reflect by answering the following questions.");
        ShowAnimation(_animationList, 2);
        Console.WriteLine("\n");

        bool time = true;
        while (time)
        {
            _i = _rnd.Next(0,_questions.Count());
            Console.Write(_questions[_i]);
            ShowAnimation(_animationList, 3);
            Console.WriteLine("\n");

            DateTime _currentTime = DateTime.Now;
            if (_currentTime > _endTime)
            {
                time = false;
            }
        }
        

    }

}