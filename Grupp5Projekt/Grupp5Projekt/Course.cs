using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Course
  {
    public string Name { get; set; }
    private Teacher Teacher { get; set; }
    public string TeacherEmail { get; set; }
    public List<Student> Students { get; set; }
    public Dictionary<string,string> Grades { get; set; }

    public int courseLength;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Course()
    {
      Name = "";
      Teacher = new Teacher();
      TeacherEmail = "";
      Students = new List<Student>();
      courseLength = 0;
      StartDate = DateTime.Now;
      EndDate = DateTime.Now;
    }

    public Course(string name,Teacher teacher,int courseLength,DateTime startDate,DateTime endDate)
    {
      this.Name = name;
      this.Teacher = teacher;
      TeacherEmail = Teacher.Email;
      this.courseLength = courseLength;
      this.StartDate = startDate;
      this.EndDate = endDate;
    }

    public void AddStudent(Student student)
    {
      Students.Add(student);
    }

    public void AddStudents(List<Student> newStudents)
    {
      foreach(Student n in newStudents)
      {
        Students.Add(n);
      }
    }

    public void AddTeacher(Teacher teacher)
    {
      Teacher = teacher;
    }

    public Teacher GetTeacher()
    {
      return Teacher;
    }

    public override string ToString()
    {
      return "Name: " + Name + "\tTeacher: " + Teacher.Name + "\t Course Length(hours): " + courseLength + "\tStart Date: " + StartDate + "\tEnd Date: " + EndDate;
    }
  }
}
