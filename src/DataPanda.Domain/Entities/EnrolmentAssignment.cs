using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class EnrolmentAssignment
    {
        public EnrolmentAssignment(int assignmentId, int enrolmentId)
        {
            AssignmentId = assignmentId;
            EnrolmentId = enrolmentId;
        }

        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public int EnrolmentId { get; set; }

        public Enrolment Enrolment { get; set; }

        public ICollection<FileSubmission> FileSubmissions { get; set; }
    }
}
