public class GoalMenu
{
    public List<string> _menuOptions;
    private List<Goal> _goals;
    private List<string> _animationList;
    public GoalMenu()
    {
        _goals = new List<Goal>();

        _menuOptions = new List<string>();
        _menuOptions.Add("(zero index)");
        _menuOptions.Add("Create new goal");
        _menuOptions.Add("Record a goal completion");
        _menuOptions.Add("View current goal list");
        _menuOptions.Add("Load a goal list from a file");
        _menuOptions.Add("Save this list to a file");
        _menuOptions.Add("Quit");

        _animationList = new List<string>();
        _animationList.Add("___");
        _animationList.Add("__-");
        _animationList.Add("_--");
        _animationList.Add("--_");
        _animationList.Add("-__");

    }

    public void ShowBasicAnimation(int _seconds=2)
    // takes in an amount of time and 
    //shows a basic animation for that amount of time.;
    {
        DateTime _now = DateTime.Now;
        DateTime _range = _now.AddSeconds(_seconds);

        while(_now < _range)
        {
            foreach(string _frame in _animationList)
            {
                Console.Write(_frame);
                Thread.Sleep(300);
                for (int i=0; i<_frame.Count();i++)
                {
                    Console.Write("\b");
                }
            }
            _now = DateTime.Now;
        }
    }

    public int GetMenuLength()
    {
        return _menuOptions.Count();
    }

    public string DisplayOptions()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the goal menu. " +
        "Please choose an option by typing in the number.");
        for(int i=1;i<GetMenuLength();i++)
        {
            Console.WriteLine($"{i}. {_menuOptions[i]}");
        }
        Console.Write("I want to... ");
        return Console.ReadLine();
    }

    public void DisplayGoals()
    {
        for(int i=0;i<_goals.Count();i++)
        {
            string _goalString = _goals[i].GetGoalString();
            Console.WriteLine($"{i+1}. {_goalString}");
        }
    }
    public void AddGoal(Goal _g)
    {
        _goals.Add(_g);
    }

    public void RunMenu()
        {
            bool x = true;
            while(x)
            {
                string schoice = DisplayOptions();
                // make sure the choice is in range;
                try
                {
                    int choice = int.Parse(schoice);
                    Console.Write($"You chose: {choice}. {_menuOptions[choice-1]}. ");
                    ShowBasicAnimation();

                    if (_menuOptions[choice] == "Quit")
                        {
                            Console.WriteLine(choice);
                            Console.WriteLine(_menuOptions[choice]);
                            ShowBasicAnimation();
                            x = false;
                        }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write($"Please choose a number between 1 and {GetMenuLength()}. ");
                    ShowBasicAnimation();
                }
                catch (FormatException)
                {
                    Console.Write($"Please enter a number. ");
                    ShowBasicAnimation();
                }
                
            }
        }
}