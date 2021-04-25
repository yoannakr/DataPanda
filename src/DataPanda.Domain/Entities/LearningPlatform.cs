using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class LearningPlatform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
