using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Teacher : User
  {  
    public Teacher(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
    {
        
    }
    public List<Course> Courses = new List<Course>();

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
