using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    /// <summary>
    /// demonstrates overrides, but also shows how Equals methods work
    /// </summary>
    #region Person class
    // Remember! Person extends Object.
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }

        // default needed due to above, note everything is 0 or empty string
        // should probably have the initialization done here.

        public Person() { }

        public override string ToString()
        {
            return string.Format($"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]");
        }

        // This is a true deep object compare

        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp = obj as Person;

                if (temp.FirstName == this.FirstName
                  && temp.LastName == this.LastName
                  && temp.Age == this.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /*
        public override bool Equals(object obj)
        {
            // No need to cast "obj" to a Person anymore,
            // as everything has a ToString() method.
            // NOTE: not really a deep compare

            return obj.ToString() == this.ToString();
        }
        */

        // Return a hash code based on a point of unique string data - in this case SSN
        public override int GetHashCode()
        {
            return SSN.GetHashCode();
        }
        #endregion
    }

    class ObjectOverridesProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");

            // NOTE: We want these to be identical to test
            // the Equals() and GetHashCode() methods.
            Person firstPerson = new Person("Homer", "Simpson", 50);
            Person secondPerson = new Person("Homer", "Simpson", 50);


            // Get stringified version of objects.
            Console.WriteLine("firstPerson.ToString() = {0}", firstPerson.ToString());
            Console.WriteLine("secondPerson.ToString() = {0}", secondPerson.ToString());

            // Test overridden Equals().
            Console.WriteLine("firstPerson == secondPerson?: {0}", firstPerson.Equals(secondPerson));

            // Test hash codes.
            Console.WriteLine("Same hash codes?: {0}", firstPerson.GetHashCode() == secondPerson.GetHashCode());
            Console.WriteLine();

            // are they really equal according to the object state?
            Console.WriteLine("first and second person objects have same == state?: {0}", object.Equals(firstPerson, secondPerson));

            // Change age of secondPerson and test again.
            Console.WriteLine("second person age now changed to 45");

            secondPerson.Age = 45;   // copy on write, objects are now different
            Console.WriteLine("firstPerson.ToString() = {0}", firstPerson.ToString());
            Console.WriteLine("secondPerson.ToString() = {0}", secondPerson.ToString());
            Console.WriteLine("firstPerson == secondPerson?: {0}", firstPerson.Equals(secondPerson));
            Console.WriteLine("first and second person objects have same hash codes?: {0}", firstPerson.GetHashCode() == secondPerson.GetHashCode());
            Console.WriteLine("first and second person objects have same == state?: {0}", object.Equals(firstPerson, secondPerson));
            Console.WriteLine();

            StaticMembersOfObject();


            Console.ReadLine();
        }

        static void StaticMembersOfObject()
        {
            // Static members of System.Object.
            Person thirdPerson = new Person("Sally", "Jones", 4);
            Person fourthPerson = new Person("Sally", "Jones", 4);
            Console.WriteLine("thirdPerson and fourthPerson have same == state?: {0}", object.Equals(thirdPerson, fourthPerson));
            Console.WriteLine("thirdPerson and fourthPerson are pointing (reference) to same object: {0}",
              object.ReferenceEquals(thirdPerson, fourthPerson));
        }
    }
}
