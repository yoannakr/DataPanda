using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPanda.Persistence.Configurations
{
    public class WikiConfiguration : IEntityTypeConfiguration<Wiki>
    {
        public void Configure(EntityTypeBuilder<Wiki> builder)
        {
            builder
                .Property(wiki => wiki.Id)
                .ValueGeneratedNever();
        }
    }
}
