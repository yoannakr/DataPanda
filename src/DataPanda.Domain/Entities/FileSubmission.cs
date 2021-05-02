namespace DataPanda.Domain.Entities
{
    public class FileSubmission
    {
        public int Id { get; set; }

        public int EnrolmentAssignmentId { get; set; }

        public EnrolmentAssignment EnrolmentAssignments { get; set; }
    }
}
