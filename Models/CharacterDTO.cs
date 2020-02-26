using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string[] CharacterEpisodes { get; set; }
        public string Planet { get; set; }
        public string[] CharacterFriends { get; set; }
    }
}
