using System;
using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class School: ObjectSchoolBase, IPlace
    {
        public int CreationYear {get; set;}

        public string Country {get; set;}

        public string City {get; set;}
        public string Adress {get; set;}

        public SchoolTypes SchoolType {get; set;}

        public List<Course> Courses {get; set;}

        public School(string name, int year) => (Name, CreationYear) = (name, year);

        public School(string name, int year, 
                      SchoolTypes type,
                      string country = "", string city = ""){
            
            (Name, CreationYear) = (name, year);
            SchoolType = type;
            Country = country;
            City = city;
        }


        public override string ToString()
        {
            return $"Name: \"{Name}\", Type: {SchoolType} \nCountry: {Country}, City: {City}";
        }

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando escuela...");
            foreach (var course in Courses)
            {
                course.CleanPlace();
            }
            Console.WriteLine($"Escuela {Name} limpio");
        }
    }
}