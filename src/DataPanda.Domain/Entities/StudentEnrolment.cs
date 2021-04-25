using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class StudentEnrolment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int EnrolmentId { get; set; }

        public Enrolment Enrolment { get; set; }

        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public ICollection<StudentEnrolmentAssignment> StudentEnrolmentAssignments { get; set; }

        public ICollection<StudentEnrolmentWiki> StudentEnrolmentWikis { get; set; }
    }
}
