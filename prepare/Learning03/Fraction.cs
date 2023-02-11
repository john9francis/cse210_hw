class Fraction
{
    // initialize attributes;
    private int _numerator;
    private int _denominator;

    // Constructors;
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    //methods;

    //getters & setters;
    public void SetTop(int top)
    {
        _numerator = top;
    }
    public int GetTop()
    {
        return _numerator;
    }

    public void SetBottom(int bottom)
    {
        _denominator = bottom;
    }
    public int GetBottom()
    {
        return _denominator;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
    public double GetDecimalValue()
    {
        return (double)_numerator/(double)_denominator;
    }
}