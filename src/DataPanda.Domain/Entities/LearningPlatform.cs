using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class LearningPlatform
    {
        public LearningPlatform(string name, string type, string url)
        {
            Name = name;
            Type = type;
            Url = url;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
