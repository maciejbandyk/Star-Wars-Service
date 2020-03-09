using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Models
{
    public class Character : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
        public string Planet { get; set; }
        public ICollection<CharacterFriend> CharacterFriends { get; set; }
    }
}
