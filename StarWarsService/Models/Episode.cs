using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsService.Models
{
    public class Episode : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
