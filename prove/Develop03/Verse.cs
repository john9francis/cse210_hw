public class Verse
{
    private string _verse;
    private List<Word> _verseWords = new List<Word>();

    public Verse()
    {
        _verse = "";
    }
    public Verse(string verse)
    {
        _verse = verse;
        CreateWordList();
    }

    // getters and setters;
    public void SetVerse(string verse)
    {
        _verse = verse;
        CreateWordList();
    }

    public string GetVerse()
    {
        string v = "";
        foreach(Word _w in _verseWords)
        {
            string _w1 = _w.GetWord();
            v += _w1;
            v += " ";
        }
        return v;
    }


    // other methods;
    private void CreateWordList()
    // this turns the verse into a list of Word objects;
    {
        string[] _words = _verse.Split(" ");
        int maximum = _words.Count();
        for (int i = 0; i < maximum;i++)
        {
            Word _word = new Word();
            _word.SetWord(_words[i]);
            _verseWords.Add(_word);
        }
    }

    public void DashRandomWords(int _min=2, int _max=4)
    /*Dashes a random amount of the words in the verse*/
    {
        Random _rnd = new Random();
        
        for (int _dashAmount = 0; _dashAmount < _rnd.Next(_min,_max); _dashAmount++)
        {   
            Random _rnd1 = new Random();
            int _dash = _rnd1.Next(0,_verseWords.Count());
            _verseWords[_dash].DashWord();
        }
    }

    public int GetUndashedWords()
    {
        int _tot = 0;
        for (int i = 0; i < _verseWords.Count(); i++)
        {
            if (_verseWords[i].dashed == false)
            {
                _tot +=1;
            }
        }

        return _tot;
    }

}