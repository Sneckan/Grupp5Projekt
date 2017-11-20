using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public class Course
    {
        public string name { get; set; }
        public Teacher teacher { get; set; }
        public List<Student> students { get; }

        int courseLength;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Course(string name,Teacher teacher,int courseLength,DateTime startDate,DateTime endDate)
        {
            this.name = name;
            this.teacher = teacher;
            this.courseLength = courseLength;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public void addStudent(Student student)
        {
            students.Add(student);
        }

        public void addStudents(List<Student> newStudents)
        {
            foreach(Student n in newStudents)
            {
                students.Add(n);
            }
        }
    }
}
