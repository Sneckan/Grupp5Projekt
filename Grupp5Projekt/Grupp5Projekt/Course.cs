using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  public class Course
  {
    [XmlIgnore]
    public List<Student> Students { get; set; }
    [XmlIgnore]
    public Teacher Teacher { get; set; }

    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Hours { get; set; }
    public List<Lesson> lessons { get; set; }
    public string TeacherEmail { get; set; }
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
      TeacherEmail = Teacher.Email;
    }

    //constructor for tests
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
      TeacherEmail = Teacher.Email;
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
      TeacherEmail = Teacher.Email;
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
        i++;
      }

      Grades[pos].StudentGrade = StudentGrade;

    }

    //Show Grades
    public string ShowGrade()
    {
      string temp = "";
      foreach(Grade grade in Grades)
      {
        temp += grade.ToString();
      }
      return temp;
    }

    //Show grades for a student
    public string ShowGradeForStudent(Student student)
    {
      int pos = -1;
      int i = 0;
      while (pos < 0 && i < Grades.Count)
      {
        if (Grades[i].StudentEmail == student.Email)
        {
          pos = i;
        }
        i++;
      }
      if (pos != -1)
      {
        return Grades[pos].StudentGrade;
      }
      else
      {
        return "Student not part of this course.";
      }
    }

    //add student to a course
    public void AddStudent(Student student)
    {
      Students.Add(student);
      Grades.Add(new Grade(student.Email, ""));
    }

    public void AddStudents(List<Student> students)
    {
      Students = students;
    }

    //remove a student from course
    public void RemoveStudent(Student student)
    {
      int i = 0;
      bool found = false;

      while (i < Students.Count && !found)
      {
        if (Grades[i].StudentEmail == student.Email)
        {
          Students.Remove(student);
          Grades.Remove(Grades[i]);
          found = true;
        }
        i++;
      }
    }

    //adds a teacher to course
    public void AddTeacher(Teacher teacher)
    {
      Teacher = teacher;
      TeacherEmail = teacher.Email;
    }

    public void RemoveTeacher()
    {
      Teacher = new Teacher();
      TeacherEmail = "";
    }
  }
}

