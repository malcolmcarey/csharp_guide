---------- Animal.cs ----------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutA.cs
{
    // If this class was sealed you couldn't inherit 
    // from it sealed class Animal
    class Animal
    {
        private string name;

        // A protected field can be changed by
        // a subclass directly
        protected string sound;

        // Inheritance has a "is-a" relationship, 
        // while an aggregation or delegate 
        // represents a "Has-a" relationship
        // like we have here with the AnimalIDInfo
        // object
        protected AnimalIDInfo animalIDInfo = new AnimalIDInfo();
  
        public void SetAnimalIDInfo(int idNum, string owner)
        {
            animalIDInfo.IDNum = idNum;
            animalIDInfo.Owner = owner;
        }

        public void GetAnimalIDInfo()
        {
            Console.WriteLine($"{Name} has the ID of {animalIDInfo.IDNum} and is owned by {animalIDInfo.Owner}");
        }

        // Added virtual so that this method can
        // be overridden by subclasses
        // You must add override to the method in 
        // the subclass
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public Animal()
        :this("No Name", "No Sound") { }

        public Animal(string name)
            :this(name, "No Sound") { }

        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!value.Any(char.IsDigit))
                {
                    name = "No Name";
                } else {
                    name = value;
                }
            }
        }

        public string Sound
        {
            get { return sound; }
            set
            {
                if(value.Length > 10)
                {
                    sound = "No Sound";
                }
                sound = value;
            }
        }

        // You can create inner classes that are 
        // normally helper classes for the outer 
        // class because it can access private
        // members of the outer class
        public class AnimalHealth
        {
            public bool HealthyWeight(double height,
                double weight)
            {
                double calc = height / weight;

                if ((calc >= .18) && (calc <= .27))
                {
                    return true;
                }
                else return false;
            }

        }

    }
}

---------- Dog.cs ----------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutA.cs
{
    // When you inherit from another class you
    // receive all of its fields and methods
    // You cannot inherit from multiple classes
    class Dog : Animal
    {
        // You can add additional properties
        // or fields
        public string Sound2 { get; set; } = "Grrrrr";

        // You can overwrite methods by adding new
        /*
        public new void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {Sound2}");
        }
        */

        // Add override so that the correct method
        // is called when a Dog is created as an
        // Animal type
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {Sound2}");
        }


        // Create a constructor that has the base 
        // constructor initialize everything except 
        // Sound2
        public Dog(string name = "No Name", 
            string sound = "No Sound", 
            string sound2 = "No Sound 2")
            :base(name, sound){
                Sound2 = sound2;
            }
    }
}

---------- Program.cs ----------

using System;

namespace CSharpTutA.cs
{
    class Program
    {

        static void Main(string[] args)
        {
            Animal whiskers = new Animal()
            {
                Name = "Whiskers",
                Sound = "Meow"
            };

            Dog grover = new Dog()
            {
                Name = "Grover",
                Sound = "Woof",
                Sound2 = "Grrrrr"
            };

            // Demonstrate changing the protected
            // field sound
            grover.Sound = "Wooooof";

            whiskers.MakeSound();
            grover.MakeSound();

            // Define the AnimalIDInfo
            whiskers.SetAnimalIDInfo(12345, "Sally Smith");
            grover.SetAnimalIDInfo(12346, "Paul Brown");

            whiskers.GetAnimalIDInfo();

            // Test the inner class
            Animal.AnimalHealth getHealth = new Animal.AnimalHealth();

            Console.WriteLine("Is my animal healthy : {0}", getHealth.HealthyWeight(11, 46));

            // You can define 2 Animal objects but have
            // one actually be a Dog type. 
            Animal monkey = new Animal()
            {
                Name = "Happy",
                Sound = "Eeeeee"
            };

            Animal spot = new Dog()
            {
                Name = "Spot",
                Sound = "Wooooff",
                Sound2 = "Geerrrr"
            };

            // The problem is that if you call a 
            // function in Animal it won't call
            // the overridden method in Dog unless
            // the method that might be overridden
            // is marked virtual
            spot.MakeSound();

            // This is an example of how Polymorphism
            // allows a subclass to override a method
            // in the super class and even if the 
            // subclass is defined as the super class
            // type the correct method will be called


            Console.ReadLine();

        }
        
    }

}

---------- AnimalIDInfo.cs ----------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutA.cs
{
    class AnimalIDInfo
    {
        public int IDNum { get; set; } = 0;
        public string Owner { get; set; } = "No Owner";

    }
}
