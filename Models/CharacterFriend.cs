using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models
{
    public class CharacterFriend
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public int FriendId { get; set; }
        public virtual Character Friend { get; set; }
    }
}
