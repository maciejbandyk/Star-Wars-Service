using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsService.Data.Core;
using StarWarsService.Models;

namespace StarWarsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : StarwarsController<CharacterDTO, CoreCharacterRepository>
    {
        public CharactersController(CoreCharacterRepository repository) : base(repository)
        {

        }
    }
}
