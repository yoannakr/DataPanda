using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent
{
    public class GetEnrolmentForStudentPersistenceQuery : IPersistenceQuery<Enrolment>
    {
        public GetEnrolmentForStudentPersistenceQuery(int studentId, int courseId, int learningPlatformId)
        {
            StudentId = studentId;
            CourseId = courseId;
            LearningPlatformId = learningPlatformId;
        }

        public int StudentId { get; }

        public int CourseId { get; }

        public int LearningPlatformId { get; }
    }
}
