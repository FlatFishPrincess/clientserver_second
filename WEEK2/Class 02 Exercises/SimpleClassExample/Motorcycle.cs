using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    /// <summary>
    /// Motorcycle class. 
    /// Demonstrates constructor chaining.
    /// </summary>
    class Motorcycle
    {

        public int driverMaxIntensity;  // driver craziness
        public string driverName;    // driver name

        #region Constructors
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public Motorcycle()
        {
            Console.WriteLine("In default ctor");
        }

        /// <summary>
        /// Constructor overloaded with one arg, setting intensity.
        /// Notice how master is called with intensity arg and a blank string for name
        /// Intensity is represents how crazy a driver is.
        /// </summary>
        /// <param name="driverMaxIntensity">driver craziness</param>
        public Motorcycle(int driverMaxIntensity)
          : this(driverMaxIntensity, "")
        {
            Console.WriteLine("In ctor taking an int");
        }

        /// <summary>
        /// Same as above, but set name and then zero for intensity using base contructor
        /// </summary>
        /// <param name="name"></param>
        public Motorcycle(string name)
          : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");

        }

        /// <summary>
        /// This is the 'master' constructor that does all the real work. Called by the 
        /// constructors above.
        /// </summary>
        /// <param name="driverMaxIntensity">Driver craziness</param>
        /// <param name="name">Driver name</param>
        public Motorcycle(int driverMaxIntensity = 0, string name = "")
        {
            Console.WriteLine("In master ctor ");

            if (driverMaxIntensity > 10)
            {
                driverMaxIntensity = 10;
            }
            this.driverMaxIntensity = driverMaxIntensity;
            driverName = name;
        }

        #endregion
        /// <summary>
        /// Set the driverName
        /// </summary>
        /// <param name="name"></param>
        public void SetDriverName(string name)
        {
            this.driverName = name;
        }


        /// <summary>
        /// Show the driver saying something as intensity increases to the driver's intensity
        /// </summary>
        public void PopAWheely()
        {
            for (int intensity = 0; intensity <= driverMaxIntensity; intensity++)
            {
                Console.WriteLine($"Wheee! {intensity} of {driverMaxIntensity}");
            }
        }

        /// <summary>
        /// Set the driver intensity (craziness)
        /// </summary>
        /// <param name="driverMaxIntensity"></param>
        public void SetIntensity(int driverMaxIntensity)
        {
            if (driverMaxIntensity > 10)
            {
                driverMaxIntensity = 10;
            }
            this.driverMaxIntensity = driverMaxIntensity;
        }

        public override string ToString()
        {
            return $"Motorcycle driver: {driverName}, intensity: {driverMaxIntensity}";
        }
    }
}
