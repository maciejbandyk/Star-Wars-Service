using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models.Configuration
{
    public class CharacterFriendsConfiguration : IEntityTypeConfiguration<CharacterFriend>
    {
        public void Configure(EntityTypeBuilder<CharacterFriend> builder)
        {
            builder.ToTable("CharacterFriend");
            builder.HasData
                (
                    new CharacterFriend { CharacterId = 1, FriendId = 3 },
                    new CharacterFriend { CharacterId = 1, FriendId = 4 },
                    new CharacterFriend { CharacterId = 1, FriendId = 6 },
                    new CharacterFriend { CharacterId = 1, FriendId = 7 },
                    new CharacterFriend { CharacterId = 2, FriendId = 5 },
                    new CharacterFriend { CharacterId = 3, FriendId = 1 },
                    new CharacterFriend { CharacterId = 3, FriendId = 4 },
                    new CharacterFriend { CharacterId = 3, FriendId = 7 },
                    new CharacterFriend { CharacterId = 4, FriendId = 1 },
                    new CharacterFriend { CharacterId = 4, FriendId = 3 },
                    new CharacterFriend { CharacterId = 4, FriendId = 6 },
                    new CharacterFriend { CharacterId = 4, FriendId = 7 },
                    new CharacterFriend { CharacterId = 5, FriendId = 2 },
                    new CharacterFriend { CharacterId = 6, FriendId = 1 },
                    new CharacterFriend { CharacterId = 6, FriendId = 3 },
                    new CharacterFriend { CharacterId = 6, FriendId = 4 },
                    new CharacterFriend { CharacterId = 6, FriendId = 7 },
                    new CharacterFriend { CharacterId = 7, FriendId = 1 },
                    new CharacterFriend { CharacterId = 7, FriendId = 3 },
                    new CharacterFriend { CharacterId = 7, FriendId = 4 }
                );
        }
    }
}
