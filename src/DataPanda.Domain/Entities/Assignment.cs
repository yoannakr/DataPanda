using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Assignment
    {
        public Assignment(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EnrolmentAssignment> EnrolmentAssignments { get; set; }
    }
}
