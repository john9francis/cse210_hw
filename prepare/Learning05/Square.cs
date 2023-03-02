public class Square : Shape
{
    private double _side;

    public void SetSide(double sidelength)
    {
        _side = sidelength;
    }
    public override double GetArea()
    {
        return _side*_side;
    }
}