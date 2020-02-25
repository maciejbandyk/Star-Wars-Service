﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsService.Models;

namespace StarWarsService.Migrations
{
    [DbContext(typeof(StarwarsContext))]
    [Migration("20200225230720_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWarsService.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Planet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterId");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            Name = "Luke Skywalker"
                        },
                        new
                        {
                            CharacterId = 2,
                            Name = "Darth Vader"
                        },
                        new
                        {
                            CharacterId = 3,
                            Name = "Han Solo"
                        },
                        new
                        {
                            CharacterId = 4,
                            Name = "Leia Organa",
                            Planet = "Alderaan"
                        },
                        new
                        {
                            CharacterId = 5,
                            Name = "Willhuff Tarkin"
                        },
                        new
                        {
                            CharacterId = 6,
                            Name = "C-3PO"
                        },
                        new
                        {
                            CharacterId = 7,
                            Name = "R2-D2"
                        });
                });

            modelBuilder.Entity("StarWarsService.Models.CharacterEpisode", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("CharacterEpisode");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            EpisodeId = 3
                        },
                        new
                        {
                            CharacterId = 2,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            EpisodeId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 3,
                            EpisodeId = 3
                        },
                        new
                        {
                            CharacterId = 4,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 4,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 4,
                            EpisodeId = 3
                        },
                        new
                        {
                            CharacterId = 5,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 6,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 6,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 6,
                            EpisodeId = 3
                        },
                        new
                        {
                            CharacterId = 7,
                            EpisodeId = 1
                        },
                        new
                        {
                            CharacterId = 7,
                            EpisodeId = 2
                        },
                        new
                        {
                            CharacterId = 7,
                            EpisodeId = 3
                        });
                });

            modelBuilder.Entity("StarWarsService.Models.CharacterFriend", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "FriendId");

                    b.HasIndex("FriendId");

                    b.ToTable("CharacterFriend");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            FriendId = 3
                        },
                        new
                        {
                            CharacterId = 1,
                            FriendId = 4
                        },
                        new
                        {
                            CharacterId = 1,
                            FriendId = 6
                        },
                        new
                        {
                            CharacterId = 1,
                            FriendId = 7
                        },
                        new
                        {
                            CharacterId = 2,
                            FriendId = 5
                        },
                        new
                        {
                            CharacterId = 3,
                            FriendId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            FriendId = 4
                        },
                        new
                        {
                            CharacterId = 3,
                            FriendId = 7
                        },
                        new
                        {
                            CharacterId = 4,
                            FriendId = 1
                        },
                        new
                        {
                            CharacterId = 4,
                            FriendId = 3
                        },
                        new
                        {
                            CharacterId = 4,
                            FriendId = 6
                        },
                        new
                        {
                            CharacterId = 4,
                            FriendId = 7
                        },
                        new
                        {
                            CharacterId = 5,
                            FriendId = 2
                        },
                        new
                        {
                            CharacterId = 6,
                            FriendId = 1
                        },
                        new
                        {
                            CharacterId = 6,
                            FriendId = 3
                        },
                        new
                        {
                            CharacterId = 6,
                            FriendId = 4
                        },
                        new
                        {
                            CharacterId = 6,
                            FriendId = 7
                        },
                        new
                        {
                            CharacterId = 7,
                            FriendId = 1
                        },
                        new
                        {
                            CharacterId = 7,
                            FriendId = 3
                        },
                        new
                        {
                            CharacterId = 7,
                            FriendId = 4
                        });
                });

            modelBuilder.Entity("StarWarsService.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.ToTable("Episode");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            Name = "NEWHOPE"
                        },
                        new
                        {
                            EpisodeId = 2,
                            Name = "EMPIRE"
                        },
                        new
                        {
                            EpisodeId = 3,
                            Name = "JEDI"
                        });
                });

            modelBuilder.Entity("StarWarsService.Models.CharacterEpisode", b =>
                {
                    b.HasOne("StarWarsService.Models.Character", "Character")
                        .WithMany("CharacterEpisodes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsService.Models.Episode", "Episode")
                        .WithMany("CharacterEpisodes")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWarsService.Models.CharacterFriend", b =>
                {
                    b.HasOne("StarWarsService.Models.Character", "Character")
                        .WithMany("CharacterFriends")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsService.Models.Character", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
