using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public class Course
    {
        public string Name { get; set; }
       // public Timetable TimeTable { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Hours { get; set; }

        public Course(string name, Teacher teacher, DateTime startDate, DateTime endDate, int hours)
        {
            Name = name;
            Teacher = teacher;
            StartDate = startDate;
            EndDate = endDate;
            Hours = hours;
        }
    }
  }

