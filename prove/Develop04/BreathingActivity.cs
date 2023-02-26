public class BreathingActivity: Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        // breathe style animation;
        _animationList = new List<string>();
        _animationList.Add(".....");
        _animationList.Add("ooooo");
        _animationList.Add("OOOOO");
        _animationList.Add("00000");
        _animationList.Add("00000");
        _animationList.Add("00000");
        _animationList.Add("OOOOO");
        _animationList.Add("ooooo");
        _animationList.Add(".....");

    }


    private void Countdown(int seconds)
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

    public void Breathe()
    {
        Console.Clear();
        // keep track of time;
        DateTime _startTime = DateTime.Now;
        DateTime _endTime = _startTime.AddSeconds(_duration);

        bool time = true;
        while (time)
        {
            Console.Write("Breathe in...");
            Countdown(2);
            Console.WriteLine();
            Console.Write("Breathe out...");
            Countdown(2);
            Console.WriteLine();

            DateTime _currentTime = DateTime.Now;
            if (_currentTime > _endTime)
            {
                time = false;
            }
        }
        

    }
}