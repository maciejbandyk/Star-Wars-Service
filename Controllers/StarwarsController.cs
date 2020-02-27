using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsService.Interfaces;
using StarWarsService.Models;

namespace StarWarsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class StarwarsController<TEntity, TRepository> : ControllerBase
        where TEntity : class, ICEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public StarwarsController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> Get()
        {
           
            return await repository.GetAllCharacters();
                
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var character = await repository.Get(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }

        [HttpPut]
        public async Task<ActionResult<TEntity>> Put(int id, TEntity character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            await repository.Update(character);
            return NoContent();
        } 

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity character)
        {
            await repository.Add(character);
            return CreatedAtAction("Get", new { CharacterId = character.CharacterId }, character);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var character = await repository.Delete(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }  
    }
}