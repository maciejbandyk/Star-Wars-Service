using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models
{
    public class Character : ICEntity
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
        public string Planet { get; set; }
        public ICollection<CharacterFriend> CharacterFriends { get; set; }
    }
}
