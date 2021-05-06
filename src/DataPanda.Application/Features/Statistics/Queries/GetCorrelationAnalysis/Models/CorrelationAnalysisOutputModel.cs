using System.Collections.Generic;

namespace DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models
{
    public class CorrelationAnalysisOutputModel
    {
        public CorrelationAnalysisOutputModel(
            IEnumerable<GradeAndWikiEditCorrelation> gradeAndWikiEditCorrelations,
            double totalGrades,
            int totalNumberOfWikiEdits,
            double correlation)
        {
            GradeAndWikiEditCorrelations = gradeAndWikiEditCorrelations;
            TotalGrades = totalGrades;
            TotalNumberOfWikiEdits = totalNumberOfWikiEdits;
            Correlation = correlation;
        }

        public IEnumerable<GradeAndWikiEditCorrelation> GradeAndWikiEditCorrelations { get; }

        public double TotalGrades { get; }

        public int TotalNumberOfWikiEdits { get; }

        public double Correlation { get; }
    }
}
