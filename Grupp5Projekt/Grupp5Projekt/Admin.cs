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

    
    //Constructor
    public Admin(string name, string email, string password,User.Privilege privilege):base(name,email,password,privilege)
    {
      Users = new List<User>();
    }

    public Admin(string name,string email,string password,User.Privilege privilege,List<User> users):base(name,email,password,privilege)
    {
      Users = users;
    }
    
    //AddUser
    public void AddUser(string name, string password, string email)
    {
      Console.WriteLine("Insert name: ");
      Name = Console.ReadLine();
      
      Console.WriteLine("Insert password: ");
      Password = Console.ReadLine();
      
      Console.WriteLine("Insert e-mail adress: ");
      Email = Console.ReadLine();
      
      var addUserList = new List<Registry>();
      var listSize = new Registry(50);
      list.Add(AddUser(Name, Password, Mail));
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
