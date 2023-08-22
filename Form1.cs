using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dropbox06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<string, Student> allStudents = new Dictionary<string, Student>();

        private void Form1_Load(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader("student.txt"))
            {
                string studentID;
                while((studentID = sr.ReadLine()) != null)
                {
                    Student s = new Student(studentID, sr.ReadLine(), double.Parse(sr.ReadLine()), double.Parse(sr.ReadLine()));
                    allStudents.Add(studentID, s);
                    studentListBox.Items.Add(s);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStudent = "";
            string studentID = "";
            if (studentListBox.SelectedIndex != 1)
            {
                selectedStudent = studentListBox.SelectedIndex.ToString();
                studentID = selectedStudent.Split(' ')[1];
                Student s = allStudents[studentID];
                UpdateGPAForm gpaForm = new UpdateGPAForm(s);
                gpaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select a student.");
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            studentListBox.Items.Clear();
            foreach(Student s in allStudents.Values)
            {
                studentListBox.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(StreamWriter sw = new StreamWriter("student.txt"))
            {
                foreach(Student s in allStudents.Values)
                {
                    sw.WriteLine(s.StudentID);
                    sw.WriteLine(s.StudentName);
                    sw.WriteLine(s.GPA);
                    sw.WriteLine(s.CreditHours);
                }
            }
            Close();
        }
    }
}
