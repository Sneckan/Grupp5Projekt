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
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string User { get; set; }

        //Constructor
        public Admin(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
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
