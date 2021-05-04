using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Enrolments.Queries.GetForStudent
{
    public class GetEnrolmentForStudentPersistenceQueryHandler : IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment>
    {
        private readonly DataPandaDbContext context;

        public GetEnrolmentForStudentPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Enrolment> Handle(GetEnrolmentForStudentPersistenceQuery query)
            => await context.Enrolments.FirstOrDefaultAsync(enrolment
                => enrolment.StudentId == query.StudentId &&
                    enrolment.CourseId == query.CourseId &&
                    enrolment.LearningPlatformId == query.LearningPlatformId);
    }
}
