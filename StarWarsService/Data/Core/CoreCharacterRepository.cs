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
        private readonly StarwarsContext context;       
        public CoreCharacterRepository(StarwarsContext context) : base(context)
        {
            this.context = GetContext();
        }


        public override async Task<List<CharacterDTO>> GetAll()
        {
            return await context.Set<Character>()
                .Select(x => CharacterToDTO(x, context))
                .ToListAsync();
        }

        public override async Task<CharacterDTO> Get(int id)
        {
            return await context.Set<Character>()
                .Where(x => x.Id == id)
                .Select(x => CharacterToDTO(x, context))
                .SingleOrDefaultAsync();
        }


        public override async Task<CharacterDTO> Add([FromBody]CharacterDTO entity)
        {
  
            var character = new Character
            {
                Id = entity.Id,
                Name = entity.Name,
                Planet = entity.Planet
            };

            context.Set<Character>().Add(character);
            await context.SaveChangesAsync();

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
                        listOfEpisodeIds.Add(episodeId.Id);
                    }
                }
                AddCharacterEpisodeRelation(listOfEpisodeIds, character.Id, context);
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
                        listOfFriendIds.Add(chars.Id);
                    }
                }
                AddCharacterFriendRelation(listOfFriendIds, character.Id, context);
            }
       
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task<CharacterDTO> Delete(int id)
        {
            var entity = await context.Set<Character>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            context.Set<Character>().Remove(entity);
            await context.SaveChangesAsync();
            return new CharacterDTO { Id = entity.Id, Name = entity.Name, Planet = entity.Planet };
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

        private static string[] GetEpisodes(int id, StarwarsContext context)
        {
            List<string> episodes = new List<string>();

            IEnumerable<Character> listOfEpisodes = context.Set<Character>()
                .Include(x => x.CharacterEpisodes)
                .ThenInclude(g => g.Episode);

            foreach (var item in listOfEpisodes)
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

        private static string[] GetFriends(int id, StarwarsContext context)
        {
            List<string> friends = new List<string>();

            IEnumerable<Character> listOfCharacters = context.Set<Character>()
                    .Include(x => x.CharacterFriends)
                    .ThenInclude(y => y.Friend);

            foreach (var item in listOfCharacters)
            {
                foreach (CharacterFriend c in item.CharacterFriends)
                {
                    if (c.CharacterId == id)
                    {
                        friends.Add(c.Friend.Name);
                    }
                }
            }
            return friends.ToArray();
        }

        private static CharacterDTO CharacterToDTO(Character itemDTO, StarwarsContext context) =>
        new CharacterDTO
        {
            Id = itemDTO.Id,
            Episodes = GetEpisodes(itemDTO.Id, context),
            Name = itemDTO.Name,
            Planet = itemDTO.Planet,
            Friends = GetFriends(itemDTO.Id, context)
        };
    }
}