using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Student : User
  {
    public List<Lesson> lessons;

    public Student(string name, string email, string password, Privilege myPrivilege) : base(name, email, password, myPrivilege)
    {
      lessons = new List<Lesson>();
    }

    public void AddLesson(Lesson lesson)
    {
      lessons.Add(lesson);
    }
  }
}
