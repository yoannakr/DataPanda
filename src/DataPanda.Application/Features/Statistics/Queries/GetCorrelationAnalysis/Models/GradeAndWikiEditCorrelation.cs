namespace DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models
{
    public class GradeAndWikiEditCorrelation
    {
        public GradeAndWikiEditCorrelation(int studentId, string courseName, double grade, int numberOfWikiEdits)
        {
            StudentId = studentId;
            CourseName = courseName;
            Grade = grade;
            NumberOfWikiEdits = numberOfWikiEdits;
        }

        public int StudentId { get; }

        public string CourseName { get; }

        public double Grade { get; }

        public int NumberOfWikiEdits { get; }
    }
}
