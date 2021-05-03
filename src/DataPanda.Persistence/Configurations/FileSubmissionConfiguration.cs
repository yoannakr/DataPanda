using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPanda.Persistence.Configurations
{
    public class FileSubmissionConfiguration : IEntityTypeConfiguration<FileSubmission>
    {
        public void Configure(EntityTypeBuilder<FileSubmission> builder)
        {
            builder
                .Property(assignment => assignment.Id)
                .ValueGeneratedNever();
        }
    }
}
