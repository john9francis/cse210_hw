public class Scripture
{
    public List<Verse> _verseList;
    public string _reference;
    public List<int> _numberList;
    
    public Scripture()
    {
        _verseList = new List<Verse>();
        _reference = "";
        _numberList = new List<int>();
    }
    public Scripture(string book, int verse)
    {
        _verseList = new List<Verse>();
        _reference = $"{book}, {verse}";
        _numberList = new List<int>();
        _numberList.Add(verse);
    }
    public Scripture(string book, int startVerse, int endVerse)
    {
        _verseList = new List<Verse>();
        _reference = $"{book}, {startVerse}-{endVerse}";
        _numberList = new List<int>();
        for (int i=startVerse; i < endVerse; i++)
        {
            _numberList.Add(i);
        }
    }

    // getters and setters;
    public void SetReference(string book, int startVerse, int endVerse)
    {
        _reference = $"{book}, {startVerse}-{endVerse}";
    }
    public string GetReference()
    {
        return _reference;
    }

    public void SetScripture(int number, Verse v)
    {
        _verseList.Add(v);
        _numberList.Add(number);
    }
    public string GetScripture()
    {
        string _completeScripture = "";
        _completeScripture += GetReference();
        _completeScripture += "\n";
        for (int i=0; i<_verseList.Count();i++)
        {
            string _verseNumber = $"{_numberList[i]}";
            _completeScripture += _verseNumber;
            _completeScripture += ". ";
            _completeScripture += _verseList[i].GetVerse();
            _completeScripture += "\n";
        }
        return _completeScripture;
    }

    public void DisplayVerseList()
    {
        for (int i=0; i<_verseList.Count();i++)
        {
           Console.WriteLine(_verseList[i].GetVerse());
        }
    }

    public void DashStuff()
    // replaces the verse in _verselist with a partially dashed version;
    {
        for (int i=0; i<_verseList.Count();i++)
        {
           Verse v = _verseList[i];
           Console.WriteLine(v.GetVerse());
           v.DashRandomWords();
           Console.WriteLine(v.GetVerse());
           _verseList[i] = v;

        }
    }

}