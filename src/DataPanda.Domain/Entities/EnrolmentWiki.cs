﻿namespace DataPanda.Domain.Entities
{
    public class EnrolmentWiki
    {
        public EnrolmentWiki(int wikiId, int enrolmentId, int numberOfEdits)
        {
            WikiId = wikiId;
            EnrolmentId = enrolmentId;
            NumberOfEdits = numberOfEdits;
        }

        public int Id { get; set; }

        public int NumberOfEdits { get; set; }

        public int WikiId { get; set; }

        public Wiki Wiki { get; set; }

        public int EnrolmentId { get; set; }

        public Enrolment Enrolment { get; set; }
    }
}
