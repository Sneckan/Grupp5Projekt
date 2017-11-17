using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public class Admin
    {
        //Propertys
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string User { get; set; }

        //Constructor
        public Admin(string name, string password, string mail)
        {
            Name = name;
            Password = password;
            Mail = mail;
        }

        //AddUser
        public void AddUser(string name, string password, string mail)
        {
            Console.WriteLine("Insert name: ");
            Name = Console.ReadLine();

            Console.WriteLine("Insert password: ");
            Password = Console.ReadLine();

            Console.WriteLine("Insert e-mail adress: ");
            Mail = Console.ReadLine();

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
