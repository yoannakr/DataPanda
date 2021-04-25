﻿using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class StudentEnrolmentAssignment
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public int StudentEnrolmentId { get; set; }

        public StudentEnrolment StudentEnrolment { get; set; }

        public ICollection<FileSubmission> FileSubmissions { get; set; }
    }
}
