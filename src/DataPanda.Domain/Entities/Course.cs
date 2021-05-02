using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Course
    {
        public Course(string name, string fieldOfApplication)
        {
            Name = name;
            FieldOfApplication = fieldOfApplication;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FieldOfApplication { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
