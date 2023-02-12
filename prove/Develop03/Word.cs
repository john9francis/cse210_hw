public class Word
{
    public string _word;
    public bool dashed;

    public Word()
    {

    }

    // setters and getters;
    public void SetWord(string w)
    {
        _word = w;
    }
    public string GetWord()
    {
        return _word;
    }

    // other methods
    public void DashWord()
    // turns the word into a string of dashes;
    {
        int _length = _word.Length;
        string _dashWord = "";
        foreach(int i in Enumerable.Range(1,_length))
        {
            _dashWord += "_";
        }
        _word = _dashWord;
        dashed = true;
    }
}