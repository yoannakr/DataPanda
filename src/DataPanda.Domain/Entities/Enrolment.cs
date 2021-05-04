﻿using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Enrolment
    {
        public Enrolment(int courseId, int learningPlatformId, int studentId, double grade)
        {
            CourseId = courseId;
            LearningPlatformId = learningPlatformId;
            StudentId = studentId;
            Grade = grade;
        }

        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int LearningPlatformId { get; set; }

        public LearningPlatform LearningPlatform { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public double Grade { get; set; }

        public ICollection<EnrolmentAssignment> EnrolmentAssignments { get; set; }

        public ICollection<EnrolmentWiki> EnrolmentWikis { get; set; }
    }
}
