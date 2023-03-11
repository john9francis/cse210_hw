using System.IO;

public class Progress
{
    public List<List<string>> _goalVectors;
    // each "goal vector" will be of the form:
    // [goalType, goalName, difficulty, completed, timesCompleted, timesToComplete]

    public int _points;
    public string _filename;
    
    public Progress()
    {
        _goalVectors = new List<List<string>>();
        _points = 0;
        _filename = "";
    }

    public void SetFilename(string name)
    {
        _filename = name;
    }
    public void SetPoints(int points)
    {
        _points = points;
    }

    public void SetGoalVector(List<string> goalVec)
    {
        _goalVectors.Add(goalVec);
    }

    public void DisplayGoalVectors()
    {
        foreach(List<string> list in _goalVectors)
        {
            int totalCount = list.Count();
            for (int i = 0; i < totalCount; i++)
            {
                string entry = list[i];
                if ((i + 1) == totalCount)
                {
                    Console.Write(entry);
                }
                else
                {
                    Console.Write(entry+",");
                }
            }
            Console.WriteLine();

            }
    }

    public void SaveGoalVectors()
    {
        //saves the data to a file in the format the class will understand later
        string filename = _filename;

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(List<string> list in _goalVectors)
            {
                int totalCount = list.Count();
                for (int i = 0; i < totalCount; i++)
                {
                    string entry = list[i];

                    if ((i + 1) == totalCount)
                    {
                        outputFile.Write(entry);
                    }
                    else
                    {
                        outputFile.Write(entry+",");
                    }
                }
                outputFile.WriteLine();

            }

        }
    }

    public void LoadGoalVectors()
    {
        string filename = _filename;
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            // taking the parts and turning them into a string list;
            List<string> vec = new List<string>();
            foreach(string part in parts)
            {
                vec.Add(part);
            }

            SetGoalVector(vec);
        }
    }

    
}