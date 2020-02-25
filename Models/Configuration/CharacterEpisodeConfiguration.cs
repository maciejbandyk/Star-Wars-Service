using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models.Configuration
{
    public class CharacterEpisodeConfiguration : IEntityTypeConfiguration<CharacterEpisode>
    {
        public void Configure(EntityTypeBuilder<CharacterEpisode> builder)
        {
            builder.ToTable("CharacterEpisode");
            builder.HasData
                (
                new CharacterEpisode { CharacterId = 1, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 1, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 1, EpisodeId = 3 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 3 },
                new CharacterEpisode { CharacterId = 3, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 3, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 3, EpisodeId = 3 },
                new CharacterEpisode { CharacterId = 4, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 4, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 4, EpisodeId = 3 },
                new CharacterEpisode { CharacterId = 5, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 6, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 6, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 6, EpisodeId = 3 },
                new CharacterEpisode { CharacterId = 7, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 7, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 7, EpisodeId = 3 }
                );
        }   
    }
}
