using GeometryLib;
using GeometryLib.Shapes;
using NUnit.Framework;

namespace GeometryLibTests;

[TestFixture]
public class GeneratorTests
{
    [Test]
    public void TypeValueTests()
    {
        //Arrange
        var triangle = ShapeGenerator.GenerateShape(new List<double>() { 3, 4, 5 });
        var circle = ShapeGenerator.GenerateShape(new List<double>() { 1 });
        
        //Assert
        Assert.IsInstanceOf<Triangle>(triangle);
        Assert.IsInstanceOf<Circle>(circle);
        Assert.That(triangle.Area, Is.EqualTo(6));
        Assert.That(circle.Area,   Is.EqualTo(Math.PI).Within(0.000001));
    }
}