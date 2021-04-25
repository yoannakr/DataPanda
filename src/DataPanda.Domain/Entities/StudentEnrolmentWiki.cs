namespace DataPanda.Domain.Entities
{
    public class StudentEnrolmentWiki
    {
        public int Id { get; set; }

        public int NumberOfEdits { get; set; }

        public int WikiId { get; set; }

        public Wiki Wiki { get; set; }

        public int StudentEnrolmentId { get; set; }

        public StudentEnrolment StudentEnrolment { get; set; }
    }
}
