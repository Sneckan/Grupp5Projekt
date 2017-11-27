using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Teacher : User
  {

    public List<Course> Courses;
    public List<Lesson> lessons;

    public Teacher()
    : base (){
      Courses = new List<Course>();
      lessons = new List<Lesson>();
    }

    public Teacher(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
    {
      Courses = new List<Course>();
      lessons = new List<Lesson>();
    }

    //adds a lesson to lesson list
    public void AddLesson(Lesson lesson)
    {
      lessons.Add(lesson);
    }

    public void AddCourseToTeacher(Course course)
    {
      Courses.Add(course);
    }

    public void AddStudentToCourse(Student student,Course course)
    {
      Courses[Courses.IndexOf(course)].Students.Add(student);
    }

    public string ShowCourses()
    {
      string temp = "";
      for (int i = 0; i < Courses.Count; i++)
      {
        temp += Courses[i].Name + "\n";
      }

      return temp;
    }

    public string ShowFinishedCourses()
    {
      string temp = "";
      foreach (var course in Courses)
      {
        if (course.EndDate < DateTime.Today)
        {
          temp += course.Name + "\n";          
        }
      }
        return temp;
    }

    public string ShowOngoingCourses()
    {
      string temp = "";
      foreach (var course in Courses)
      {
        if (course.EndDate > DateTime.Today)
        {
          temp += course.Name + "\n";
        }
      }
      return temp;
    }

  }
}
