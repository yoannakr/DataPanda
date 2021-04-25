using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public ICollection<StudentEnrolment> StudentEnrolments { get; set; }
    }
}
