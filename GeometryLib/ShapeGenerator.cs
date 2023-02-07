using GeometryLib.Shapes;

namespace GeometryLib;

public static class ShapeGenerator
{
    public static IShape GenerateShape(List<double> sides) =>
        sides.Count switch
        {
            1 => new Circle(sides[0]),
            3 => new Triangle(sides[0], sides[1], sides[2]),
            _ => throw new ArgumentOutOfRangeException(nameof(sides), "Incompatible number of sides")
        };
}