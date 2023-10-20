using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3._3._2
{
    //Included Graded and Month in the enum so it will be what displays on the combo box but they are unreachable on the set block
    enum Grade
    {
        Grade, A, B, C, D, F 
    }
    enum Month
    {
        Month, January, February, March, April, May, June, July, August, September, October, November, December
    }

    internal struct Student
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Month MonthOfAdmission { get; set; }
        public Grade StudentGrade { get; set; }

    }
}
