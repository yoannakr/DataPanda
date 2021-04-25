namespace DataPanda.Domain.Entities
{
    public class FileSubmission
    {
        public int Id { get; set; }

        public int StudentEnrolmentAssignmentId { get; set; }

        public StudentEnrolmentAssignment StudentEnrolmentAssignments { get; set; }
    }
}
