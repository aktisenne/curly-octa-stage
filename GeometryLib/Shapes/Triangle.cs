using System.Diagnostics.Contracts;

namespace GeometryLib.Shapes
{
    public class Triangle : IShape
    {
        public double A { get; }

        public double B { get; }

        public double C { get; }

        public double Area => GetArea(A, B, C);

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();
            
            if (!IsValid(a, b, c))
                throw new ArgumentException();
            
            A = a;
            B = b;
            C = c;
        }

        private static bool IsValid(double a, double b, double c) => 
            a + b > c && a + c > b && b + c > a;

        private static double GetArea(double a, double b, double c) 
        {
            var halfSum = (a + b + c) / 2;
            return Math.Sqrt(halfSum * (halfSum - a) * (halfSum - b) * (halfSum - c)); //heron's formula
        }

        public bool IsRight() => IsRight(A, B, C);

        private static bool IsRight(double a, double b, double c)
        {
            const float tolerance = .1f;
            return Math.Abs(a * a + b * b - c * c) < tolerance || 
                   Math.Abs(a * a + c * c - b * b) < tolerance ||
                   Math.Abs(b * b + c * c - a * a) < tolerance;
        }
    }
}