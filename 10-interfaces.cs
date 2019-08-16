// ---------- IDrivable.cs ----------

namespace CSharpTutA.cs
{
    // An interface is a class with nothing but
    // abstract methods. Interfaces are used
    // to represent a contract an object may
    // decide to support.

    // Interfaces commonly have names that
    // are adjectives because adjectives
    // modify nouns (Objects). The also
    // describe abstract things

    // It is common to prefix your interfaces with 
    // an I

    interface IDrivable
    {
        // Interfaces can have properties
        int Wheels { get; set; }
        double Speed { get; set; }

        // Classes that inherit an interface
        // must fulfill the contract and 
        // implement every abstract method
        void Move();
        void Stop();
    }
}

// ---------- Vehicle.cs ----------

using System;

namespace CSharpTutA.cs
{
    class Vehicle : IDrivable
    {
        // Vehicle properties
        public string Brand { get; set; }

        public Vehicle(string brand = "No Brand",
            int wheels = 0,
            double speed = 0)
        {
            Brand = brand;
            Wheels = wheels;
            Speed = speed;
        }

        // Properties and methods from
        // the interface
        public double Speed {get; set;}

        public int Wheels {get; set;}

        public void Move()
        {
            Console.WriteLine($"The {Brand} Moves Forward at {Speed} MPH");
        }

        public void Stop()
        {
            Console.WriteLine($"The {Brand} Stops");
            Speed = 0;
        }
    }
}

// ---------- Program.cs ----------

using System;

// A class can support multiple interfaces. 

// Create an interface Project -> Add New Item
// and select Interface

namespace CSharpTutA.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Vehicle object
            Vehicle buick = new Vehicle("Buick",
                4, 160);

            // Check if Vehicle implements 
            // IDrivable
            if(buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            } else
            {
                Console.WriteLine("The {0} can't be driven", buick.Brand);
            }

            // We are now modeling the act of
            // picking up a remote, aiming it
            // at the TV, clicking the power
            // button and then watching as
            // the TV turns on and off

            // Pick up the TV remote
            IElectronicDevice TV = TVRemote.GetDevice();

            // Create the power button
            PowerButton powBut = new PowerButton(TV);

            // Turn the TV on and off with each 
            // press
            powBut.Execute();
            powBut.Undo();

            Console.ReadLine();

        }
        
    }

}

// ---------- IElectronicDevice.cs ----------

namespace CSharpTutA.cs
{
    // With interfaces you can create very
    // flexible systems. Here I'll model
    // generic electronic devices like 
    // TVs and Radios and remotes that 
    // control them and the buttons on the
    // remotes. 
    interface IElectronicDevice
    {
        // We want each device to have 
        // these capabilities
        void On();
        void Off();
        void VolumeUp();
        void VolumeDown();

    }
}

// ---------- Television.cs ----------

using System;

namespace CSharpTutA.cs
{
    // Because we implemented the 
    // ElectronicDevice interface any
    // other device we create will know
    // exactly how to interface with it.
    class Television : IElectronicDevice
    {
        public int Volume { get; set; }

        public void Off()
        {
            Console.WriteLine("The TV is Off");
        }

        public void On()
        {
            Console.WriteLine("The TV is On");
        }

        public void VolumeDown()
        {
            if (Volume != 0) Volume--;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }

        public void VolumeUp()
        {
            if (Volume != 100) Volume++;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }
    }
}

// ---------- ICommand.cs ----------

namespace CSharpTutA.cs
{
    interface ICommand
    {
        // We can model what happens when
        // a button is pressed for example
        // a power button. By breaking
        // everything down we can add
        // an infinite amount of flexibility
        void Execute();
        void Undo();
    }
}

// ---------- PowerButton.cs ----------

namespace CSharpTutA.cs
{
    class PowerButton : ICommand
    {
        // You can refer to instances using
        // the interface
        IElectronicDevice device;

        // Now we get into the specifics of
        // what happens when the power button
        // is pressed.
        public PowerButton(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            device.On();
        }

        // You can provide a way to undo
        // an action just like the power 
        // button does on a remote
        public void Undo()
        {
            device.Off();
        }
    }
}

// ---------- TVRemote.cs ----------

namespace CSharpTutA.cs
{
    class TVRemote
    {
        // Now we are modeling the action of
        // picking up the remote with our hand
        public static IElectronicDevice GetDevice()
        {
            return new Television();
        }
    }
}
