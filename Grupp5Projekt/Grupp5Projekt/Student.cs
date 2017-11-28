using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Student : User
  {
    public List<Lesson> lessons { get; set; }

    public Student()
      : base()
    {
      MyPrivilege = Privilege.student;
      lessons = new List<Lesson>();
    }

    public Student(string name, string email, string password, Privilege myPrivilege) : base(name, email, password, myPrivilege)
    {
      lessons = new List<Lesson>();
    }

    public Student(string name, string email, string password) : base(name, email, password)
    {
      lessons = new List<Lesson>();
      MyPrivilege = Privilege.student;
    }


    public void AddLesson(Lesson lesson)
    {
      lessons.Add(lesson);
    }
    
  }
}
