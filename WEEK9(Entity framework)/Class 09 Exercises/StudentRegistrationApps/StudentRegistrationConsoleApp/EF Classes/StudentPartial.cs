using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationConsoleApp.EF_Classes
{
    public partial class Student
    {
        public override string ToString()
        {
            return $"{StudentId} {StudentFirstName} {StudentLastName} {StudentMajor}";
        }
    }
}
