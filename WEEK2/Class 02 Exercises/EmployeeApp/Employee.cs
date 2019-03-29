﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    /// <summary>
    /// Contains all employee fields and methods.
    ///     Includes id, name, pay, age, and social security number
    /// </summary>
    class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN = "";

        #region Constructors
        // Note use of constructor chaining.

        // default constructor
        public Employee() { }

        // three arg contructor invokes the 4 arg one with age set to zero
        public Employee(string name, int id, float pay)
          : this(name, 0, id, pay)
        {
        }

        // full 4 arg constructor 
        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }
        #endregion

        #region Class methods 
        public void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name} ID: {ID} Age: {Age} Pay: {Pay}");
        }
        #endregion

        #region Properties 
        // Properties!
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error!  Name length exceeds 15 characters");
                else
                    empName = value;
            }
        }

        // We could add additional business rules to the sets of these properties,
        // however there is no need to do so for this example.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }
        #endregion

        #region Traditional Get / Set method
        // Accessor (get method)
        public string GetName()
        {
            return empName;
        }

        // Mutator (set method)
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                Console.WriteLine("Error!  Name must be less than 15 characters!");
            else
                empName = name;
        }
        #endregion
    }
}