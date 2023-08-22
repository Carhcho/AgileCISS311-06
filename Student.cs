using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dropbox06
{
    class Student
    {
        private string studentID;
        private string studentName;
        private double gpa;
        private double creditHours;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public string StudentName
        {
            get { return studentName; }
            set { StudentName = value; }
        }
        public double GPA
        {
            get { return gpa; }
            set { gpa = value; }
        }
        public double CreditHours
        {
            get { return creditHours; }
            set { creditHours = value; }
        }
        public Student(string studentID, string studentName, double gpa, double creditHours)
        {
            this.studentID = studentID;
            this.studentName = studentName;
            this.gpa = gpa;
            this.creditHours = creditHours;
        }
        public void UpdateGPA(char courseGrade, double courseCredit)
        {
            courseGrade = char.ToUpper(courseGrade);
            double courseGpa;
            if(courseGrade == 'A')
            {
                courseGpa = 4.0;
            }
            else if(courseGrade == 'B')
            {
                courseGpa = 3.0;
            } 
            else if(courseGrade == 'C')
            {
                courseGpa = 2.0;
            }
            else if(courseGrade == 'D')
            {
                courseGpa = 1.0;
            }
            else
            {
                courseGpa = 0.0;
            }
            GPA = (GPA * CreditHours + courseGpa * courseCredit) / (creditHours + courseCredit);
            CreditHours += courseCredit;
        }
        public override string ToString()
        {
            string str;
            str = string.Format($"ID: {studentID} " + $"Name: {studentName} " + $"GPA: {GPA:N2} Credit Hours: {creditHours} ");
            return str;
        }
    }
}