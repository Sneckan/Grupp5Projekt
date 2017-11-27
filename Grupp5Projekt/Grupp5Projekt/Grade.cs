using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Grade
  {

    public string StudentEmail { get; set; }
    public string StudentGrade { get; set; }

    public Grade()
    {
      StudentEmail = "";
      StudentGrade = "";
    }

    public Grade(string StudentEmail,string StudentGrade)
    {
      this.StudentEmail = StudentEmail;
      this.StudentGrade = StudentGrade;
    }


    public override string ToString()
    {
      return "Student Email: " + StudentEmail + "\tGrade: " + StudentGrade + "\n";
    }

  }
}
