using System;

namespace DataPanda.Domain.Entities
{
    public class ActivityLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Context { get; set; }

        public string Component { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
