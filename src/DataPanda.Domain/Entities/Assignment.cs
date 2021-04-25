using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentEnrolmentAssignment> StudentEnrolmentAssignments { get; set; }
    }
}
