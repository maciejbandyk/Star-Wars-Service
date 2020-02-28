using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Data.Core
{
    public class CoreCharacterRepository : CoreRepository<CharacterDTO, StarwarsContext>
    {
        public readonly StarwarsContext context;
        public CoreCharacterRepository(StarwarsContext context) : base(context)
        {
            this.context = GetContext();
        }


        [HttpGet]
        public override async Task<List<CharacterDTO>> GetAll()
        {
            return await context.Set<Character>()
                .Select(x => CharacterToDTO(x, context))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public override async Task<CharacterDTO> Get(int id)
        {
            return await context.Set<Character>()
                .Where(x => x.CharacterId == id)
                .Select(x => CharacterToDTO(x, context))
                .SingleOrDefaultAsync();
        }


        [HttpPost]
        public override async Task<CharacterDTO> Add(CharacterDTO entity)
        {

            var character = new Character
            {
                CharacterId = entity.CharacterId,
                Name = entity.Name,
                Planet = entity.Planet
            };

            context.Set<Character>().Add(character);
            context.SaveChanges();

            var listOfEpisodeIds = new List<int>();
            if (entity.Episodes.Length != 0)
            {
                var episodesInDb = context.Episodes.ToList();
                var episodesStringified = context.Episodes
                    .Select(x => x.Name)
                    .ToList();
                
                foreach (var ep in entity.Episodes)
                {
                    if (episodesStringified.Contains(ep.ToUpper()))
                    {
                        Episode episodeId = episodesInDb.Find(x => x.Name.Contains(ep));
                        listOfEpisodeIds.Add(episodeId.EpisodeId);
                    }
                }
                AddCharacterEpisodeRelation(listOfEpisodeIds, character.CharacterId, context);
            }

            if(entity.Friends.Length != 0)
            {
                var friendsInDb = context.Characters.ToList();
                var friendsStringified = context.Characters
                    .Select(x => x.Name)
                    .ToList();
                var listOfFriendIds = new List<int>();
                foreach (var friend in entity.Friends)
                {
                    if (friendsStringified.Contains(friend))
                    {
                        Character chars = friendsInDb.Find(x => x.Name.Contains(friend));
                        listOfFriendIds.Add(chars.CharacterId);
                    }
                }
                AddCharacterFriendRelation(listOfFriendIds, character.CharacterId, context);
            }
       
            await context.SaveChangesAsync();
            return entity;
        }

        // REWIZJA
        [HttpDelete]
        public override async Task<CharacterDTO> Delete(int id)
        {
            var entity = await context.Set<Character>().FindAsync(id);
            if (entity == null)
            {
                return new CharacterDTO { CharacterId = entity.CharacterId, Name = entity.Name, Planet = entity.Planet };
            }

            context.Set<Character>().Remove(entity);
            await context.SaveChangesAsync();
            return new CharacterDTO { CharacterId = entity.CharacterId, Name = entity.Name, Planet = entity.Planet };
        }

        private static void AddCharacterEpisodeRelation(List<int> list, int id, StarwarsContext context)
        {
            list.ForEach(x => {
                var charEp = new CharacterEpisode
                {
                    CharacterId = id,
                    EpisodeId = x
                };
                context.Set<CharacterEpisode>().Add(charEp);  
            });
        }

        private static void AddCharacterFriendRelation(List<int> list, int id, StarwarsContext context)
        {
            list.ForEach(x => {
                var charEp = new CharacterFriend
                {
                    CharacterId = id,
                    FriendId = x
                };
                context.Set<CharacterFriend>().Add(charEp);
            });
        }

        protected static string[] GetEpisodes(int id, StarwarsContext context)
        {
            List<string> episodes = new List<string>();

            IEnumerable<Character> test = context.Set<Character>()
                .Include(x => x.CharacterEpisodes)
                .ThenInclude(g => g.Episode);

            foreach (var item in test)
            {
                foreach (CharacterEpisode e in item.CharacterEpisodes)
                {
                    if (e.CharacterId == id)
                    {
                        episodes.Add(e.Episode.Name);
                    }
                }
            }
            return episodes.ToArray();
        }

        private static string[] GetFriends(string name, StarwarsContext context)
        {
            IEnumerable<Character> test = context.Set<Character>()
                    .Include(x => x.CharacterFriends);
            List<string> friends = new List<string>();
            var dictionary = new Dictionary<string, List<int>>();
            foreach (var item in test)
            {
                List<int> friendsList = new List<int>();
                foreach (CharacterFriend friend in item.CharacterFriends)
                {
                    friendsList.Add(friend.FriendId);
                }
                dictionary.Add(item.Name, friendsList);
            }

            foreach (var keyValuePair in dictionary)
            {
                foreach (int values in keyValuePair.Value)
                {
                    var result = context.Set<Character>()
                        .Where(x => x.CharacterId == values)
                        .Select(x => x.Name).ToList();
                    foreach (string friendName in result)
                    {
                        if (keyValuePair.Key == name) { friends.Add(friendName); }
                    }
                }
            }

            return friends.ToArray();
        }

        private static CharacterDTO CharacterToDTO(Character itemDTO, StarwarsContext context) =>
        new CharacterDTO
        {
            CharacterId = itemDTO.CharacterId,
            Episodes = GetEpisodes(itemDTO.CharacterId, context),
            Name = itemDTO.Name,
            Planet = itemDTO.Planet,
            Friends = GetFriends(itemDTO.Name, context)
        };
    }
}