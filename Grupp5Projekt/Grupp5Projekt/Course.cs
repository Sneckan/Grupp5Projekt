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
    private List<Student> Students { get; set; }
    public List<string> StudentEmails { get; set; }
    private Dictionary<string,string> Grades { get; set; }

    public int courseLength;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Course()
    {
      Name = "";
      Teacher = new Teacher();
      TeacherEmail = "";
      Students = new List<Student>();
      StudentEmails = new List<string>();
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

    public Course(string name, int courseLength, DateTime startDate, DateTime endDate)
    {
      this.Name = name;
      this.courseLength = courseLength;
      this.StartDate = startDate;
      this.EndDate = endDate;
    }

    public void AddStudent(Student student)
    {
      Students.Add(student);
      StudentEmails.Add(student.Email);
    }

    public void AddStudents(List<Student> newStudents)
    {
      foreach(Student n in newStudents)
      {
        Students.Add(n);
        StudentEmails.Add(n.Email);
      }
    }

    public void AddTeacher(Teacher teacher)
    {
      Teacher = teacher;
      TeacherEmail = teacher.Email;
    }

    public Teacher GetTeacher()
    {
      return Teacher;
    }

    public List<Student> GetStudents()
    {
      return Students;
    }

    public override string ToString()
    {
      if(Teacher==null)
      {
        return "Name: " + Name + "\nTeacher: none\nCourse Length(hours): " + courseLength + "\nStart Date: " + StartDate + "\nEnd Date: " + EndDate + "\n";

      }
      else
      {
      return "Name: " + Name + "\nTeacher: " + Teacher.Name + "\nCourse Length(hours): " + courseLength + "\nStart Date: " + StartDate + "\nEnd Date: " + EndDate+"\n";
      }
    }
  }
}
