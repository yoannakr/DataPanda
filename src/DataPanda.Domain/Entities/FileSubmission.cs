namespace DataPanda.Domain.Entities
{
    public class FileSubmission
    {
        public FileSubmission(int id, int enrolmentAssignmentId, int numberOfFiles)
        {
            Id = id;
            EnrolmentAssignmentId = enrolmentAssignmentId;
            NumberOfFiles = numberOfFiles;
        }

        public int Id { get; set; }

        public int EnrolmentAssignmentId { get; set; }

        public int NumberOfFiles { get; set; }

        public EnrolmentAssignment EnrolmentAssignment { get; set; }
    }
}
