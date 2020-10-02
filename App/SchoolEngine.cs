using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;

namespace CoreSchool
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {

        }
        public void Initialize()
        {
            School = new School("Platzi Academay", 2012, SchoolTypes.Elementary,
            city: "Bogotá", country: "Colombia");

            LoadCourses();
            LoadSubjects();
            LoadEvaluations();
    
        }

        public List<ObjectSchoolBase> GetObjectSchool()
        {
            var listObj = new List<ObjectSchoolBase>();
            listObj.Add(School);
            listObj.AddRange(School.Courses);

            foreach (var course in School.Courses)
            {
                listObj.AddRange(course.Subjects);
                listObj.AddRange(course.Students);
                foreach (var student in course.Students)
                {
                    listObj.AddRange(student.Evaluations);
                }
            }
            return listObj;
        }
        #region Load Methods
        private void LoadEvaluations()
        {
            var list = new List<Evaluation>();
            foreach (var course in School.Courses)
            {
                foreach (var subject in course.Subjects)
                {
                    foreach (var student in course.Students)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for(int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluation{
                                Subject = subject,
                                Name = $"{subject.Name} Ev#{i + 1}",
                                Grade = (float)(5 * rnd.NextDouble()),
                                Student = student
                            };
                            student.Evaluations.Add(ev);
                        }
                    }
                }
            }
        }

        private void LoadSubjects()
        {
            foreach (var curso in School.Courses)
            {
                var listaAsignaturas = new List<Subject>(){
                            new Subject{Name="Matemáticas"} ,
                            new Subject{Name="Educación Física"},
                            new Subject{Name="Castellano"},
                            new Subject{Name="Ciencias Naturales"}
                };
                curso.Subjects = listaAsignaturas;
            }
        }

        private void LoadCourses()
        {
            School.Courses = new List<Course>(){
                        new Course(){ Name = "101", DayTime = DayTimes.Morning },
                        new Course(){Name = "201", DayTime = DayTimes.Morning},
                        new Course(){Name = "301", DayTime = DayTimes.Morning},
                        new Course(){ Name = "401", DayTime = DayTimes.Afternoon },
                        new Course(){Name = "501", DayTime = DayTimes.Afternoon},
            };
            
            Random rnd = new Random();
            foreach(var c in School.Courses)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Students = GenerarAlumnosAlAzar(cantRandom);
            }
        }
        #endregion
        
        private List<Student> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Student{ Name=$"{n1} {n2} {a1}" };
            
            return listaAlumnos.Take(cantidad).ToList();
        }
    }
}