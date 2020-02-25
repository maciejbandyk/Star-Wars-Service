using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsService.Models.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsService.Models
{
    public class StarwarsContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<CharacterFriend> CharacterFriends { get; set; }

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

            

            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterEpisodeConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterFriendsConfiguration());
            
        }
    }      
}
