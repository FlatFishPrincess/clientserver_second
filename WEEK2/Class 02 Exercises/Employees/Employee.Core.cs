﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // this is a partial class that can be extended in other files.

    partial class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN = "";

        #region Constructors

        // Note use of constructor chaining.
        public Employee() { }
        public Employee(string name, int id, float pay)
          : this(name, 0, id, pay)
        {
        }

        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        // Add to the Employee base class.
        public Employee(string name, int age, int id, float pay, string ssn) 
            : this(name, age, id, pay)
        {
            empSSN = ssn;
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

        // Contains a BenefitPackage object.
        // use nested class

        protected BenefitPackage empBenefits = new BenefitPackage();

        // use standalone class
        public Employees.BenefitPackage empBenefits2 = new Employees.BenefitPackage();


        // Expose certain benefit behaviors of object. 
        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

        // Expose object through a custom property.
        // use nested class

        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

        // use standalone class
        //public Employees.BenefitPackage Benefits
        //{
        //    get { return empBenefits; }
        //    set { empBenefits = value; }
        //}

    }
}
