using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetCorrelationAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Features.Statistics.Queries.GetCorrelationAnalysis
{
    public class GetCorrelationAnalysisPersistenceQueryHandler : IPersistenceQueryHandler<GetCorrelationAnalysisPersistenceQuery, CorrelationAnalysisOutputModel>
    {
        private readonly DataPandaDbContext context;

        public GetCorrelationAnalysisPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<CorrelationAnalysisOutputModel> Handle(GetCorrelationAnalysisPersistenceQuery query)
        {
            var enrolments = await context.Enrolments
                .Include(enrolment => enrolment.EnrolmentWikis)
                .Include(enrolment => enrolment.Course)
                .Where(enrolment => enrolment.Course.Name == query.CourseName)
                .ToListAsync();

            var correlations = new List<GradeAndWikiEditCorrelation>();

            if (enrolments.Count == 0)
            {
                return new CorrelationAnalysisOutputModel(correlations, 0, 0, 0);
            }

            foreach (var enrolment in enrolments)
            {
                var numberOfWikiEdits = enrolment.EnrolmentWikis?.Sum(enrolmentWiki => enrolmentWiki.NumberOfEdits) ?? 0;
                var correlation = new GradeAndWikiEditCorrelation(enrolment.Id, enrolment.Course.Name, enrolment.Grade, numberOfWikiEdits);

                correlations.Add(correlation);
            }

            var sumX = correlations.Sum(correlation => correlation.Grade);
            var sumY = correlations.Sum(correlation => correlation.NumberOfWikiEdits);
            var sumXY = correlations.Sum(correlation => correlation.Grade * correlation.NumberOfWikiEdits);
            var sumXX = correlations.Sum(correlation => correlation.Grade * correlation.Grade);
            var sumYY = correlations.Sum(correlation => correlation.NumberOfWikiEdits * correlation.NumberOfWikiEdits);

            var numberOfEnrolments = enrolments.Count();

            var totalCorrelation = (numberOfEnrolments * sumXY - sumX * sumY) / Math.Sqrt((numberOfEnrolments * sumXX - sumX * sumX) * (numberOfEnrolments * sumYY - sumY * sumY));

            return new CorrelationAnalysisOutputModel(correlations, sumX, sumY, totalCorrelation);
        }
    }
}
