public class GoalMenu
{
    private List<string> _menuOptions;
    public List<Goal> _goals;
    private List<string> _animationList;

    // different goal lists:
    List<Goal> _normal;
    List<Goal> _eternal;
    List<Goal> _checklist;
    List<Goal> _completed;
    List<Goal> _other;


    public GoalMenu()
    {
        _normal = new List<Goal>();
        _eternal = new List<Goal>();
        _checklist = new List<Goal>();
        _completed = new List<Goal>();
        _other = new List<Goal>();

        _goals = new List<Goal>();

        _menuOptions = new List<string>();
        _menuOptions.Add("(zero index)");
        _menuOptions.Add("Create new goal");
        _menuOptions.Add("Record a goal completion");
        _menuOptions.Add("View current goal list");
        _menuOptions.Add("See my score");
        _menuOptions.Add("Save this list to a file");
        _menuOptions.Add("Load a goal list from a file");
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

    // FUNCTIONS USED IN THE MENU_________________________________________
    
    public void DisplayGoals()
    {
        
        for(int i=0;i<_goals.Count();i++)
        {
            string _goalString = _goals[i].GetGoalString();
            Console.WriteLine($"{i+1}. {_goalString}");
        }

        /*
        List<Goal> OrganizeGoals()
        {
            List<Goal> _organizedGoals = new List<Goal>();
            List<string> _pattern = new List<string>();
            _pattern.Add("Normal");
            _pattern.Add("Eternal");
            _pattern.Add("Checklist");
            _pattern.Add("Completed");

            for(int i=0; i<_pattern.Count(); i++)
            {
                foreach(Goal g in _goals)
                {
                    if (_pattern[i] == "Completed")
                    {
                        if(g.IsCompleted())
                        {
                            _organizedGoals.Add(g);
                        }
                    }
                    else
                    {
                        if(!g.IsCompleted() && g.GetGoalType() == _pattern[i])
                        {
                            _organizedGoals.Add(g);
                        }
                    }
                }
            }

            return _organizedGoals;
        }
        */
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Normal Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int goalType = int.Parse(Console.ReadLine());

        string sgoalType = "";
        Goal g;

        if (goalType == 1)
        {
            g = new NormalGoal();
            sgoalType = "Normal";
            g.SetGoal();
            _goals.Add(g);
        }
        else if (goalType == 2)
        {
            g = new EternalGoal();
            sgoalType = "Eternal";
            g.SetGoal();
            _goals.Add(g);
        }
        else if (goalType == 3)
        {
            g = new ChecklistGoal();
            sgoalType = "Checklist";
            g.SetGoal();
            _goals.Add(g);
        }
    
        Console.Write($"Creating {sgoalType} goal...");
        ShowBasicAnimation(); 

    }
    public void RecordGoalCompletion()
    {
        Console.Clear();
        Console.WriteLine("Which goal would you like to complete?");
        DisplayGoals();
        int c = int.Parse(Console.ReadLine())-1;
        _goals[c].CompleteGoal();
        Console.WriteLine("Goal successfully completed.");
        Console.WriteLine(_goals[c].GetGoalString());
        ShowBasicAnimation(3); 
        
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
    public void SaveProgress()
    {
        Console.Clear();
        Progress p = new Progress();

        // get the goal vectors into the progress class
        foreach(Goal goal in _goals)
        {
            p.SetGoalVector(goal.GetGoalVector());
        }
        
        // save the goal vectors to a file:
        Console.Write("Name your file: (you don't have to write .txt after) ");
        string filename = Console.ReadLine() + ".txt";
        p.SetFilename(filename);
        p.SaveGoalVectors();

        Console.WriteLine("Saving file...");
        ShowBasicAnimation();
        Console.WriteLine($"{filename} successfully saved.");
        ShowBasicAnimation();
    }

    public void LoadProgress()
    {
        Console.Clear();
        Progress p = new Progress();

        // get filename
        Console.Write("Please enter the filename to load from. " +
        "(you don't have to write .txt after) ");
        string filename = Console.ReadLine() + ".txt";

        // load the file into progress
        p.SetFilename(filename);
        p.LoadGoalVectors();

        // get the goal vectors into our goal list.
        // each "goal vector" will be of the form:
        // [goalType, goalName, difficulty, completed, timesCompleted, timesToComplete]
        foreach(List<string> goalVector in p._goalVectors)
        {
            if(goalVector[0] == "Normal")
            {
                //Normal goal
                Goal g = new NormalGoal();
                g.ReverseGoalVector(goalVector);
                _goals.Add(g);
            }
            else if(goalVector[0] == "Eternal")
            {
                //Eternal goal
                Goal g = new EternalGoal();
                g.ReverseGoalVector(goalVector);
                _goals.Add(g);
            }
            else if(goalVector[0] == "Checklist")
            {
                //Checklist goal
                Goal g = new ChecklistGoal();
                g.ReverseGoalVector(goalVector);
                _goals.Add(g);
            }
            else
            {
                //unrecognized
            }
        }

        // tell the user it's done
        Console.Write($"Loading goals from {filename}...");
        ShowBasicAnimation();
        Console.WriteLine();
        Console.Write($"Goals successfully loaded from {filename}.");
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

                    if (_menuOptions[choice] == "Quit")
                    {
                        x = false;
                    }
                    else if (choice == 1)
                    {
                        CreateGoal();
                    }
                    else if (choice == 2)
                    {
                        RecordGoalCompletion();
                    }
                    else if (choice == 3)
                    {
                        ViewGoalList();
                    }
                    else if (choice == 4)
                    {
                        ViewScore();
                    }
                    else if (choice == 5)
                    {
                        SaveProgress();
                    }
                    else if (choice == 6)
                    {
                        LoadProgress();
                    }
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