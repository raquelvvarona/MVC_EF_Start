using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Enrolment> enrolments { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Enrolment> enrolments { get; set; }
    }

    public class Enrolment
    {
        public int Id { get; set; }

        public Course course { get; set; }
        public Student student { get; set; }

        public string grade { get; set; }
    }
}