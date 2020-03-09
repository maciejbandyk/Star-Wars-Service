using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarWarsService.Models.Configuration
{
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.ToTable("Episode");

            builder.HasData
            (
                new Episode
                {
                    Id = 1,
                    Name = "NEWHOPE"
                },
                new Episode
                {
                    Id = 2,
                    Name = "EMPIRE"
                },
                new Episode
                {
                    Id = 3,
                    Name = "JEDI"
                }
            );
        }
    }
}
