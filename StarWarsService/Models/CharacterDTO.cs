using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsService.Models
{
    public class CharacterDTO : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Episodes { get; set; }
        public string Planet { get; set; }
        public string[] Friends { get; set; }
    }
}
