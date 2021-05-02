using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class StudentEnrolment
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int LearningPlatformId { get; set; }

        public LearningPlatform LearningPlatform { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public double Grade { get; set; }

        public ICollection<StudentEnrolmentAssignment> StudentEnrolmentAssignments { get; set; }

        public ICollection<StudentEnrolmentWiki> StudentEnrolmentWikis { get; set; }
    }
}
