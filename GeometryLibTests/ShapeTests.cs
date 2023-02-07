using System.Runtime.CompilerServices;
using GeometryLib;
using GeometryLib.Shapes;
using NUnit.Framework;

namespace GeometryLibTests;

[TestFixture]
public class ShapeTests
{
    private const float AreaTolerance = 0.001f;

    private Triangle _triangle0;
    private Triangle _triangle1;
    private Triangle _triangle2;
    private Triangle _triangle3;
    private Triangle _triangle4;

    [SetUp]
    public void Setup()
    {
        _triangle0 = new Triangle(3, 4, 5);
        _triangle1 = new Triangle(1000000, 1000000, 1000000);
        _triangle2 = new Triangle(0.000000003, 0.000000004, 0.000000005);
        _triangle3 = new Triangle(30, 30, 30);
        _triangle4 = new Triangle(80, 80, 1);
    }

    [Test]
    public void TriangleConstructorExceptions()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, 0));
        Assert.Throws<ArgumentException>(() => new Triangle(2, 8, 10));
        Assert.Throws<ArgumentException>(() => new Triangle(4, 6, 20));
    }

    [Test]
    public void TriangleArea()
    {
        Assert.That(_triangle0.Area, Is.EqualTo(6)               .Within(AreaTolerance));
        Assert.That(_triangle1.Area, Is.EqualTo(433012701892.219).Within(AreaTolerance));
        Assert.That(_triangle2.Area, Is.EqualTo(6E-27)           .Within(AreaTolerance));
        Assert.That(_triangle3.Area, Is.EqualTo(389.7114)        .Within(AreaTolerance));
        Assert.That(_triangle4.Area, Is.EqualTo(40)              .Within(AreaTolerance));
    }

    [Test]
    public void RightTriangle()
    {
        Assert.True (_triangle0.IsRight());
        Assert.False(_triangle1.IsRight());
        Assert.True (_triangle2.IsRight());
        Assert.False(_triangle3.IsRight());
        Assert.False(_triangle4.IsRight());
    }

    [Test]
    public void CircleConstructorExceptions()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-10));
    }

    [Test]
    public void GetCircleArea()
    {
        // Arrange
        var circle0 = new Circle(1.0);
        var circle1 = new Circle(0.00045);
        var circle2 = new Circle(46.9504);
        var circle3 = new Circle(39.3502);
        var circle4 = new Circle(39.5321);

        // Assert
        Assert.That(circle0.Area, Is.EqualTo(Math.PI)   .Within(AreaTolerance));
        Assert.That(circle1.Area, Is.EqualTo(6.3617E-7).Within(AreaTolerance));
        Assert.That(circle2.Area, Is.EqualTo(6925.1385).Within(AreaTolerance));
        Assert.That(circle3.Area, Is.EqualTo(4864.5621).Within(AreaTolerance));
        Assert.That(circle4.Area, Is.EqualTo(4909.6399).Within(AreaTolerance));
    }
}