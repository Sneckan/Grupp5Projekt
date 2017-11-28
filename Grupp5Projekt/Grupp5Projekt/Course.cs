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
    // public Timetable TimeTable { get; set; }
    public Teacher Teacher { get; set; }
    
    public List<Student> Students { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Hours { get; set; }
    public List<Lesson> lessons { get; set; }

    public List<Grade> Grades { get; set; }

    public Course()
    {
      Name = "";
      Teacher = new Teacher();
      StartDate = DateTime.Now;
      EndDate = DateTime.Now;
      Hours = 2;
      lessons = new List<Lesson>();
      Grades = new List<Grade>();
      Students = new List<Student>();
    }


    public Course(string v)
    {
      Name = v;
      Teacher = new Teacher();
      StartDate = DateTime.Now;
      EndDate = DateTime.Now;
      Hours = 2;
      lessons = new List<Lesson>();
      Grades = new List<Grade>();
      Students = new List<Student>();
    }

    //constructor gives values to everything
    public Course(string name, Teacher teacher, DateTime startDate, DateTime endDate, int hours)
    {
      Name = name;
      Teacher = teacher;
      StartDate = startDate;
      EndDate = endDate;
      Hours = hours;
      lessons = new List<Lesson>();
      Grades = new List<Grade>();
      Students = new List<Student>();
    }
    //puts lesson in lesson list
    public void AddLessonToCourse(Lesson lesson)
    {
      lessons.Add(lesson);
    }

    //Grade a student

    public void GradeStudent(string StudentEmail,string StudentGrade)
    {
      int pos = -1;
      int i = 0;
      while(pos<0&&i<Grades.Count)
      {
        if(Grades[i].StudentEmail==StudentEmail)
        {
          pos = i;
        }
      }

      Grades[pos].StudentGrade = StudentGrade;

    }

    public string ShowGrade()
    {
      string temp = "";
      foreach(Grade grade in Grades)
      {
        temp += grade.ToString();
      }
      return temp;
    }

    public void AddStudent(Student student)
    {
      Students.Add(student);
      Grades.Add(new Grade(student.Email, ""));

    }

    public void AddStudents(List<Student> students)
    {
      Students = students;
    }
  }
}

