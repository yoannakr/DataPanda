using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Wiki
    {
        public Wiki(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EnrolmentWiki> EnrolmentWikis { get; set; }

    }
}
