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
                    Id = 1,
                    Name = "Luke Skywalker",              
                },
                new Character
                {
                    Id = 2,
                    Name = "Darth Vader",
                },
                new Character
                {
                    Id = 3,
                    Name = "Han Solo"
                },
                new Character
                {
                    Id = 4,
                    Name = "Leia Organa",
                    Planet = "Alderaan"
                },
                new Character
                {
                    Id = 5,
                    Name = "Willhuff Tarkin"
                },
                new Character
                {
                    Id = 6,
                    Name = "C-3PO"
                },
                new Character
                {
                    Id = 7,
                    Name = "R2-D2"
                }
            );
        }
    }
}
