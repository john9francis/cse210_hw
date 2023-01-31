public class Menu
{
    
    public List<string> _options = new List<string>();

    public void DisplayOptions()
    {
        Console.WriteLine("What would you like to do?");
        for (int i=0; i<_options.Count; i++)
        {
            Console.WriteLine(_options[i]);
        }
    }


}