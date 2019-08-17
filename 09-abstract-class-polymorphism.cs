// ---------- Shape.cs ----------
using System;

// Very often you want to define a
// class that you don't want to be
// instantiated. In that case an 
// Abstract class may be the way to
// go. 

namespace CSharpTutA.cs
{
    abstract class Shape
    {
        public string Name { get; set; }

        // You can define non-abstract
        // methods in an abstract class
        public virtual void GetInfo()
        {
            Console.WriteLine($"This is a {Name}");
        }

        // We want subclasses to override
        // this method so mark it as abstract
        // You can only make abstract methods 
        // in abstract classes
        public abstract double Area();

    }
}

// ---------- Circle.cs ----------

using System;

namespace CSharpTutA.cs
{
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * (Math.Pow(Radius, 2.0));
        }

        // You can replace the method using override
        public override void GetInfo()
        {
            // Execute the base version
            base.GetInfo();
            Console.WriteLine($"It has a Radius of {Radius}");
        }

    }
}

// ---------- Rectangle.cs ----------

using System;

namespace CSharpTutA.cs
{
    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length,
            double width)
        {
            Name = "Rectangle";
            Length = length;
            Width = width;
        }

        public override double Area()
        {
            return Length * Width;
        }

        // You can replace the method using override
        public override void GetInfo()
        {
            // Execute the base version
            base.GetInfo();
            Console.WriteLine($"It has a Length of {Length} and Width of {Width}");
        }
    }
}

// ---------- Program.cs ----------

using System;

// This time we cover Abstract Classes, Abstract
// Methods, Base Classes, Is, As, Casting and
// more about Polymorphism

namespace CSharpTutA.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // We can store our shapes in
            // a Shape array as long as it 
            // contains subclasses of Shape
            Shape[] shapes = {new Circle(5),
            new Rectangle(4,5)};

            // Cycle through shapes and print
            // the area
            foreach(Shape s in shapes)
            {
                // Call the overidden method
                s.GetInfo();

                Console.WriteLine("{0} Area : {1:f2}",
                s.Name, s.Area());

                // You can use as to check if an
                // object is of a specific type
                Circle testCirc = s as Circle;
                if(testCirc == null)
                {
                    Console.WriteLine("This isn't a Circle");
                }

                // You can use is to check the data
                // type
                if(s is Circle)
                {
                    Console.WriteLine("This isn't a Rectangle");
                }


                Console.WriteLine();
            }

            // You can store any class as a base
            // class and call the subclass methods
            // even if they don't exist in the base
            // class by casting
            object circ1 = new Circle(4);

            Circle circ2 = (Circle)circ1;
            Console.WriteLine("The {0} Area is {1:f2}",
                circ2.Name, circ2.Area());
            

            Console.ReadLine();

        }
        
    }

}
