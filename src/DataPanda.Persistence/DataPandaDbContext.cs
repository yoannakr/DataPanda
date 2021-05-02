using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataPanda.Persistence
{
    public class DataPandaDbContext : DbContext
    {
        public DataPandaDbContext(DbContextOptions<DataPandaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<FileSubmission> FileSubmissions { get; set; }

        public DbSet<LearningPlatform> LearningPlatforms { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<EnrolmentAssignment> EnrolmentAssignments { get; set; }

        public DbSet<EnrolmentWiki> EnrolmentWikis { get; set; }

        public DbSet<Wiki> Wikis { get; set; }
    }
}
