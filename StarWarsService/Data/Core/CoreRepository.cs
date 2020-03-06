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

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
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
        
        public virtual async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }


        public virtual async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;     
            await context.SaveChangesAsync();
            return entity;
        }

        public TContext GetContext() => context;

    }
}
