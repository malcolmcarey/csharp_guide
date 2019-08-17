// ---------- Animal.cs ----------

namespace CSharpTutA.cs
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name = "No Name")
        {
            Name = name;
        }
    }
}

// ---------- AnimalFarm.cs ----------

using System.Collections;
using System.Collections.Generic;

namespace CSharpTutA.cs
{
    // IEnumerable provides for iteration 
    // over a collection
    class AnimalFarm : IEnumerable
    {
        // Holds list of Animals
        private List<Animal> animalList = new List<Animal>();

        public AnimalFarm(List<Animal> animalList)
        {
            this.animalList = animalList;
        }

        public AnimalFarm()
        {
        }

        // Indexer for AnimalFarm created with this[]
        public Animal this[int index]
        {
            get { return (Animal)animalList[index]; }
            set { animalList.Insert(index, value); }
        }

        // Returns the number of values in the 
        // collection
        public int Count
        {
            get{
                return animalList.Count;
            }
        }

        // Returns an enumerator that is used to 
        // iterate through the collection
        IEnumerator IEnumerable.GetEnumerator()
        {
            return animalList.GetEnumerator();
        }


    }
}

// ---------- Box.cs ----------

using System;

namespace CSharpTutA.cs
{
    class Box
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }

        public Box() 
        :this(1,1,1) { }

        public Box(double l,
            double w,
            double b)
        {
            Length = l;
            Width = w;
            Breadth = b;
        }

        public static Box operator +(Box box1, Box box2)
        {
            Box newBox = new Box()
            {
                Length = box1.Length + box2.Length,
                Width = box1.Width + box2.Width,
                Breadth = box1.Breadth + box2.Breadth
            };
            return newBox;
        }

        // Through operator overloading you can
        // allow users to interact with your
        // custom objects in interesting ways
        // You can overload +, -, *, /, %, !,
        // ==, !=, >, <, >=, <=, ++ and --
        public static Box operator -(Box box1, Box box2)
        {
            Box newBox = new Box()
            {
                Length = box1.Length - box2.Length,
                Width = box1.Width - box2.Width,
                Breadth = box1.Breadth - box2.Breadth
            };
            return newBox;
        }

        public static bool operator ==(Box box1, Box box2)
        {
            if((box1.Length == box2.Length) &&
                (box1.Width == box2.Width) &&
                (box1.Breadth == box2.Breadth))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Box box1, Box box2)
        {
            if ((box1.Length != box2.Length) ||
                (box1.Width != box2.Width) ||
                (box1.Breadth != box2.Breadth))
            {
                return true;
            }
            return false;
        }

        // You define how your object is converted
        // into a string by overridding ToString
        public override string ToString()
        {
            return String.Format("Box with Height : {0} Width : {1} and Breadth : {2}",
                Length, Width, Breadth);
        }

        // You can convert from a Box into an
        // int like this even though this
        // wouldn't make sense
        public static explicit operator int(Box b)
        {
            return (int)(b.Length + b.Width + b.Breadth) / 3;
        }

        // Convert from an int to a Box
        public static implicit operator Box(int i)
        {
            // Return a box with the lengths all
            // set to the int passed
            return new Box(i, i, i);
        }

    }
}

// ---------- Program.cs ----------

using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpTutA.cs
{
    // Indexers allow you to access items
    // like arrays

    class Program
    {

        static void Main(string[] args)
        {
            // Create an AnimalFarm object
            AnimalFarm myAnimals = new AnimalFarm();

            // Add Animals
            myAnimals[0] = new Animal("Wilbur");
            myAnimals[1] = new Animal("Templeton");
            myAnimals[2] = new Animal("Gander");
            myAnimals[3] = new Animal("Charlotte");

            foreach(Animal i in myAnimals)
            {
                Console.WriteLine(i.Name);
            }

            // Testing operator overloading
            Box box1 = new Box(2, 3, 4);
            Box box2 = new Box(5,6,7);

            Box box3 = box1 + box2;

            // Converts the box to a string with
            // ToString
            Console.WriteLine($"Box 3 : {box3}");

            Console.WriteLine($"Box Int : {(int)box3}");

            // Convert an int into a Box
            Box box4 = (Box)4;

            Console.WriteLine($"Box 4 : {(Box)4}");

            // Sometimes you want to build a simple
            // class that contains fields and
            // Anonymous types are great for that
            var shopkins = new { Name = "Shopkins", Price = 4.99 };

            Console.WriteLine("{0} cost ${1}",
                shopkins.Name, shopkins.Price);

            // Anonymous types can also be stored 
            // in an array

            var toyArray = new[] { new {
                Name = "Yo-Kai Pack", Price = 4.99 },
                new { Name = "Legos", Price = 9.99 } };

            // You can loop through the array
            foreach(var item in toyArray)
            {
                Console.WriteLine("{0} costs ${1}",
                    item.Name, item.Price);
            }

            Console.WriteLine();

            Console.ReadLine();

        }

    }

}
