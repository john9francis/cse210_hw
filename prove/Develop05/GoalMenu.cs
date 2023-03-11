public class GoalMenu
{
    private List<string> _menuOptions;
    public List<Goal> _goals;
    private List<string> _animationList;
    public GoalMenu()
    {
        _goals = new List<Goal>();

        _menuOptions = new List<string>();
        _menuOptions.Add("(zero index)");
        _menuOptions.Add("Create new goal");
        _menuOptions.Add("Record a goal completion");
        _menuOptions.Add("View current goal list");
        _menuOptions.Add("See my score");
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

    public void ShowBasicAnimation(int _seconds=1)
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

    public string DisplayOptions()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the goal menu. " +
        "Please choose an option by typing in the number.");
        for(int i=1;i<_menuOptions.Count();i++)
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

    // FUNCTIONS USED IN THE MENU_________________________________________
    public void CreateGoal()
    {
        Console.Clear();
        NormalGoal g = new NormalGoal();
        g.SetGoal();
        _goals.Add(g);
        Console.Write("Creating goal...");
        ShowBasicAnimation(); 
    }
    public void RecordGoalCompletion()
    {
        Console.Clear();
        if(_goals.Count() == 0)
        {
            Console.WriteLine("There are no goals yet. " + 
            "Add a goal or load a goal list from a file.");
            ShowBasicAnimation();
        }
        else
        {
            Console.WriteLine("Which goal would you like to complete?");
            DisplayGoals();
            int c = int.Parse(Console.ReadLine())-1;
            _goals[c].CompleteGoal();
            Console.WriteLine("Goal successfully completed.");
            Console.WriteLine(_goals[c].GetGoalString());
            ShowBasicAnimation(3); 
        }
    }
    public void ViewGoalList()
    {
        Console.Clear();
        Console.WriteLine("Goal List:");
        if (_goals.Count() == 0)
        {
            Console.WriteLine("The goal list is empty. Add some new goals!");
        }
        else
        {
            DisplayGoals();
        }
        Console.Write("Press enter to go back to main menu: ");
        Console.ReadLine();
        ShowBasicAnimation();
    }
    public void ViewScore()
    {
        Console.Clear();
        int points = 0;
        foreach(Goal _g in _goals)
        {
            points += _g.GetPoints();
        }
        Console.WriteLine($"Your current score is: {points} points.");
        Console.Write("Press enter to go back to main menu: ");
        Console.ReadLine();
        ShowBasicAnimation();
    }

    //________________________________________________________________________

    public void RunMenu()
        {
            bool x = true;
            while(x)
            {
                string schoice = DisplayOptions();
                try
                {
                    int choice = int.Parse(schoice);
                    
                    // we dont want them to choose zero:
                    if (choice == 0){throw new ArgumentOutOfRangeException();}

                    Console.WriteLine($"You chose: {choice}. "+
                    $"{_menuOptions[choice]}. ");
                    ShowBasicAnimation();

                    if (_menuOptions[choice] == "Quit"){x = false;}
                    else if (choice == 1){CreateGoal();}
                    else if (choice == 2){RecordGoalCompletion();}
                    else if (choice == 3){ViewGoalList();}
                    else if (choice == 4){ViewScore();}
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write($"Please choose a number in range. ");
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