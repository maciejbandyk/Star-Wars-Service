using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarWarsService.Models
{
    public class StarwarsContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public StarwarsContext(DbContextOptions<StarwarsContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterEpisode>()
                .HasKey(t => new { t.CharacterId, t.EpisodeId });

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(ce => ce.Character)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(ce => ce.CharacterId);

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(ce => ce.Episode)
                .WithMany(e => e.CharacterEpisodes)
                .HasForeignKey(ce => ce.EpisodeId);

            modelBuilder.Entity<CharacterFriend>(c =>
            {
                c.HasKey(e => new { e.CharacterId, e.FriendId });
                c.HasOne(e => e.Character).WithMany(e => e.CharacterFriends);
                c.HasOne(e => e.Friend).WithMany().OnDelete(DeleteBehavior.ClientSetNull);
            });

            //modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
            //modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        }
    }

    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.ToTable("Episode");

            builder.HasData
            (
                new Episode
                {
                    EpisodeId = 1,
                    Name = "NEWHOPE"
                },
                new Episode
                {
                    EpisodeId = 2,
                    Name = "EMPIRE"
                },
                new Episode
                {
                    EpisodeId = 3,
                    Name = "JEDI"
                }
            );
        }
    }
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
