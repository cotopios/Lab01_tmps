using System;

namespace LSPExample
{
    public abstract class Shape
    {
        public abstract double Area();
    }

    
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }
    }

   
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override double Area()
        {
            return SideLength * SideLength;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            var shapes = new Shape[]
            {
                new Rectangle { Width = 4, Height = 5 },
                new Square { SideLength = 4 },
                new Circle { Radius = 3 }
            };

           
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Aria formei este: {shape.Area()}");
            }

            Console.ReadLine();
        }
    }
}
