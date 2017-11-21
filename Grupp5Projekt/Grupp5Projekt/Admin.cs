using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Admin : User
  {
    //Propertys
    
    public List<User> Users { get; set; }
    public List<Lesson> Lessons { get; set; }

    
    //Constructor
    public Admin(string name, string email, string password,User.Privilege privilege):base(name,email,password,privilege)
    {
      Users = new List<User>();
      Lessons = new List<Lesson>();
    }

    //Constructor with existing lists from registry
    public Admin(string name,string email,string password,User.Privilege privilege,List<User> users,List<Lesson> lessons):base(name,email,password,privilege)
    {
      Users = users;
      Lessons = lessons;
    }

    public void AddLesson(Lesson lesson)
    {
      Lessons.Add(lesson);
    }
    
    //Add User to list methods
    public void AddTeacher(string name,string email,string passsword)
    {
      Users.Add(new Teacher(name, email, passsword, User.Privilege.teacher));
    }

    public void AddStudent(string name,string email,string password)
    {
      Users.Add(new Student(name, email, password, User.Privilege.student));
    }

    public void AddAdmin(string name,string email,string password)
    {
      Users.Add(new Admin(name, email, password, User.Privilege.admin));
    }
    
    //public void RemoveUser()
    //{
    //    Console.WriteLine("Remove user number: ");
    //    User = Console.ReadLine();
    
    //    var list = new list<Registry>();
    //    var listSize = new Registry(50);
    //    list.Add(2);
    //    list.Add(new Registry(2));
    
    //    var index = list.IndexOf(2);
    //    list.Remove(2);
    //    list.RemoveAt(0);
    
    //}
  }
}
