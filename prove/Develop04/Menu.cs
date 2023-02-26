public class Menu
{
    private List<string> _menuOptions;
    
    public Menu()
    {
        _menuOptions = new List<string>();
        _menuOptions.Add("Breathing Activity");
        _menuOptions.Add("Reflection Activity");
        _menuOptions.Add("Listing Activity");


    }

    public int DisplayMenu()
    /*Displays menu of options and returns an integer of the choice*/
    {
        Console.Clear();
        for(int i=0;i<_menuOptions.Count();i++)
        {
            Console.WriteLine($"{i+1}. {_menuOptions[i]}");
        }
        
        // return choice as an int;
        Console.Write("Please select your choice, then press enter: ");
        return int.Parse(Console.ReadLine());
    }

    public string GetMenuOption(int i)
    /*Takes in an int and returns the list index of that int.*/
    {
        return _menuOptions[i-1];
    }
}