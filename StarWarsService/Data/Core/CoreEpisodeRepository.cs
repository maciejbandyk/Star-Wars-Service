using Microsoft.AspNetCore.Mvc;
using StarWarsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Data.Core
{
    public class CoreEpisodeRepository : CoreRepository<Episode, StarwarsContext>
    {
        private readonly StarwarsContext context;

        public CoreEpisodeRepository(StarwarsContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<List<Episode>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<Episode> Get(int id)
        {  
            return await base.Get(id);
        }


        public override async Task<Episode> Add([FromBody]Episode entity)
        {

            context.Set<Episode>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Episode> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
