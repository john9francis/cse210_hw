public class Scripture
/*Creates a scripture that's made up of multiple verses, verse numbers, and
a scripture reference. */
{
    // setup stuff;-------------------------------------------------------;
    private List<Verse> _verseList;
    private string _reference;
    
    private List<int> _verseNumbers; // must be private so it doesn't get messed uppublic Scripture()
    {
        _verseList = new List<Verse>();
        _reference = "";
        _verseNumbers = new List<int>();
    }
    public Scripture(string book, int chapter, int startVerse, int endVerse =0)
    {
        if (endVerse == 0)
        {
            _verseList = new List<Verse>();
            _reference = $"{book} {chapter}, {startVerse}";
            _verseNumbers = new List<int>();
            _verseNumbers.Add(startVerse);
        }
        else
        {
            _verseList = new List<Verse>();
            _reference = $"{book} {chapter}, {startVerse}-{endVerse}";
            _verseNumbers = new List<int>();
            for (int i=startVerse; i<endVerse; i++)
            {
                _verseNumbers.Add(i);
            }
        }
        
    }

    //--------------------------------------------------------------------------;
    public void SetScriptureVerse(Verse _verse, int i)
    {
        _verseList.Add(_verse);
        _verseNumbers.Add(i);
    }
    private Verse GetScriptureVerse(int i)
    {
        return _verseList[i];
    }
    public void SetScriptureReference(string book, int chapter, int startVerse, int endVerse=0)
    {
        if (endVerse == 0)
        {
            _reference = $"{book} {chapter}, {startVerse}";
        }
        else
        {
            _reference = $"{book} {chapter}, {startVerse}-{endVerse}";
        }
    }
    public string GetScriptureReference()
    {
        return _reference;
    }

    public List<Verse> GetVerseList()
    {
        return _verseList;
    }

    public string GetFullScripture()
    {
        string _fullScripture = "";
        _fullScripture += GetScriptureReference();
        _fullScripture += ": ";
        _fullScripture += "\n";
        for (int i=0; i<_verseList.Count(); i++)
        {
            _fullScripture += _verseNumbers[i];
            _fullScripture += ": ";
            _fullScripture += GetScriptureVerse(i).GetVerse();
            _fullScripture += "\n";
        }
        return _fullScripture;
    }

    public void DashStuff()
    {
        foreach(Verse v in _verseList)
        {
            v.DashRandomWords();
        }
    }

}

