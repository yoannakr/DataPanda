using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Enrolment
    {
        public Enrolment(int courseId, int learningPlatformId)
        {
            CourseId = courseId;
            LearningPlatformId = learningPlatformId;
        }

        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int LearningPlatformId { get; set; }

        public LearningPlatform LearningPlatform { get; set; }

        public ICollection<StudentEnrolment> StudentEnrolments { get; set; }
    }
}
