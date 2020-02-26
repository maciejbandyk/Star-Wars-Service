using StarWarsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsService.Data.Core
{
    public class CoreCharacterRepository : CoreRepository<Character, StarwarsContext>
    {
        public CoreCharacterRepository(StarwarsContext context) : base(context)
        {

        }
    }
}
