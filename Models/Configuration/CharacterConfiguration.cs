using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace StarWarsService.Models.Configuration
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");

            builder.HasData
            (
                new Character
                {
                    CharacterId = 1,
                    Name = "Luke Skywalker",              
                },
                new Character
                {
                    CharacterId = 2,
                    Name = "Darth Vader",
                },
                new Character
                {
                    CharacterId = 3,
                    Name = "Han Solo"
                },
                new Character
                {
                    CharacterId = 4,
                    Name = "Leia Organa",
                    Planet = "Alderaan"
                },
                new Character
                {
                    CharacterId = 5,
                    Name = "Willhuff Tarkin"
                },
                new Character
                {
                    CharacterId = 6,
                    Name = "C-3PO"
                },
                new Character
                {
                    CharacterId = 7,
                    Name = "R2-D2"
                }
            );
        }
    }
}
