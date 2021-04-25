using System.Collections.Generic;

namespace DataPanda.Domain.Entities
{
    public class Wiki
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentEnrolmentWiki> StudentEnrolmentWikis { get; set; }

    }
}
