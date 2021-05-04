using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Student
    {
        public Student(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
