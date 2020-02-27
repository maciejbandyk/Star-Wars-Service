using StarWarsService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsService.Interfaces;
using StarWarsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace StarWarsService.Data.Core
{
    public abstract class CoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, ICEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        public CoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<CharacterDTO>> GetAllCharacters()
        {
            return await context.Set<Character>()
                .Select(x => CharacterToDTO(x, context))
                .ToListAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;     
            await context.SaveChangesAsync();
            return entity;
        }

        private static string[] GetEpisodes(int id, TContext context)
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

        private static string[] GetFriends(string name, TContext context)
        {
            IEnumerable<Character> test = context.Set<Character>()
                    .Include(x => x.CharacterFriends);
            List<string> friends = new List<string>();
            var dictionary = new Dictionary<string, List<int>>();
            foreach (var item in test)
            {
                List<int> a = new List<int>();
                foreach (CharacterFriend friend in item.CharacterFriends)
                {
                    a.Add(friend.FriendId);
                }
                dictionary.Add(item.Name, a);
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

        private static CharacterDTO CharacterToDTO(Character itemDTO, TContext context) =>
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
