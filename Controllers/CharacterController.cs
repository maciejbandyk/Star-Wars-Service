using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsService.Models;

namespace StarWarsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ILogger<CharacterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return new List<Character>
            {
                new Character { Id = 1, Name = "Luke Skywalker" , Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" } , Friends = new string[] { "Han Solo", "Leia Organa", "C-3PO", "R2-D2" } },
                new Character { Id = 2, Name = "Darth Vader", Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" }, Friends = new string[]{ "Wilhuff Tarkin" } },
                new Character { Id = 3, Name = "Han Solo", Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" }, Friends = new string[]{ "Luke Skywalker", "Leia Organa", "R2-D2" } },
                new Character { Id = 4, Name = "Leia Organa", Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" }, Planet = "Alderaan", Friends = new string[]{ "Luke Skywalker", "Han Solo", "C-3PO", "R2-D2" } },
                new Character { Id = 5, Name = "Wilhff Tarkin", Episodes = new string[]{ "NEWHOPE" }, Friends = new string[]{ "Darth Vader" } },
                new Character { Id = 6, Name = "C-3PO", Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" }, Friends = new string[]{ "Luke Skywalker", "Han Solo", "Leia Organa", "R2-D2" } },
                new Character { Id = 7, Name = "R2-D2", Episodes = new string[]{ "NEWHOPE", "EMPIRE", "JEDI" }, Friends = new string[]{ "Luke Skywalker", "Han Solo", "Leia Organa" } },
            };
        }
        
    }
}