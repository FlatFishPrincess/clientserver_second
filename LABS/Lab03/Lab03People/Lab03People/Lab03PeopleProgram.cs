using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03People
{
    class Lab03PeopleProgram
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8},
                new Person {FirstName= "Maggie", LastName="Simpson", Age=2},
                new Person {FirstName= "Ned", LastName="Flanders", Age=42},
                new Person {FirstName= "Maude", LastName="Flanders", Age=40},
                new Person {FirstName= "Rod", LastName="Flanders", Age=12},
                new Person {FirstName= "Todd", LastName="Flanders", Age=13}
            };

            // TASK: display the list using your generic Display method

            Display("Initial array", people);

            // TASK: create a list from the array and display it

            // your code goes here

            // TASK: sort the list using the default comparer (last name then first name) and display it

            // your code goes here

            // TASK: shuffle the list (NOT THE ARRAY) and display it 

            // your code goes here

            // TASK: sort the list by first name and display

            // your code goes here

            // TASK: create a stack and push each element onto the stack

            // stack creation code goes here

            // TASK: reverse the top two elements.
            // pop the top and save, then pop the next one and save
            // then push the top and next - reverses the elements
            // finally display the stack

            // your code goes here

            // TASK: sort the list by age

            // TASK: create a queue and add the list to the queue
            // TASK: add two elements to the end of the queue
            // TASK: display the queue
            // TASK: display the number of elements in the queue

            // your code goes here

            // TASK: finally, dequeue each element and show that they left.

            // TASK: display the number of elements in the queue

            // your code goes here

            Console.ReadLine();
        }

        // Display a generic Person collection
        // use IEnumarable so we can use foreach(), but could have used a standard index
        // and a for() loop instead

        static void Display<T>(string message, T l) where T : IEnumerable<Person>
        {
            Console.WriteLine("==============");
            // Your code here
        }
    }

    // Sort classes. You will see compiler errors here until you add the code with a proper return value.

    class SortPeopleByFirstName : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            // Your code here. Needs to return an int 1, 0, -1

        }
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            // Your code here. Needs to return an int 1, 0, -1
        }
    }

    /// <summary>
    /// Person class
    /// contains their age and first/last name
    /// 
    /// You must implement IComparable method to allow for sorting by last name then first name
    /// </summary>

    public class Person : IComparable
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        // ToString() override to make it easy to display

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}",
                FirstName, LastName, Age);
        }
    }
}
