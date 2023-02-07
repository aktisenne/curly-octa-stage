namespace GeometryLib.Shapes;

public readonly struct Circle : IShape
{
    public double Radius { get; }

    public double Area => GetArea(Radius);

    public Circle(double radius)
    {
        if (!IsValid(radius))
            throw new ArgumentOutOfRangeException(nameof(radius));
        
        Radius = radius;
    }

    private static bool IsValid(double radius) => radius > 0; 

    private static double GetArea(double radius)
    {
        return radius * radius * Math.PI; 
    }
}  