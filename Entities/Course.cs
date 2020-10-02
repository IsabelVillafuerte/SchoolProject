using System;
using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class Course: ObjectSchoolBase, IPlace
    {
        public DayTimes DayTime {get; set;}
        public List<Subject> Subjects{get; set;}
        public List<Student> Students{get; set;}
        public string Adress {get; set;}

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando establecimiento...");
            Console.WriteLine($"Curso {Name} limpio");
        }
    }
}