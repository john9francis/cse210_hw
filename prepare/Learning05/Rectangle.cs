public class Rectangle : Shape
{
    private double _length;
    private double _width;
    public void SetLengthAndWidth(double length, double width)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }

}