using Moq;
using StarWarsService.Data.Core;
using StarWarsService.Interfaces;
using StarWarsService.Models;
using System;
using StarWarsService.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace web_api_tests
{
    public class CharacterControllerTests
    {
        protected string connectionString = "server=(localdb)\\MSSQLLocalDB;database=StarwarsDB;MultipleActiveResultSets=true;";
        protected DbContextOptionsBuilder<StarwarsContext> optionsBuilder = new DbContextOptionsBuilder<StarwarsContext>();
        protected StarwarsContext starwarsContext;
        protected StarwarsContext getContext() => starwarsContext;

        protected Mock<IRepository<CoreCharacterRepository>> mock;
        protected CoreCharacterRepository core;
        protected CharactersController characterController;  

        public CharacterControllerTests()
        {
            optionsBuilder.UseSqlServer(connectionString);
            starwarsContext = new StarwarsContext(optionsBuilder.Options);
            core = new CoreCharacterRepository(starwarsContext);

            mock = new Mock<IRepository<CoreCharacterRepository>>();
            characterController = new CharactersController(core);     
        }

        [Fact]
        public async void GetById_UnknownIdPassed_RetrunNotFoundResult()
        {  
            //Act
            var notFound = await characterController.Get(999);
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }

        [Fact]
        public async void GetById_KnownIdPassed_RetrunNotNull()
        {   
            //Act
            var found = await characterController.Get(1);

            //Assert
            Assert.NotNull(found.Value);
        }

        [Fact]
        public void GetById_KnownIdPassed_ReturnRightElement()
        {
            //Arrange
            int id = 1;
            //Act
            var result = characterController.Get(1).Result;
            //Assert
            Assert.IsType<CharacterDTO>(result.Value);
            Assert.Equal(id, (result.Value as CharacterDTO).CharacterId);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            //Act
            var result = characterController.Get().Result;
            //Assert
            var items = Assert.IsType<List<CharacterDTO>>(result.Value);
            Assert.True(items.Count > 5);   
        }

        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var invalidCharacter = new CharacterDTO()
            {
                CharacterId = 70,
                Episodes = new string[] { "NEW HOPE" },
                Planet = "Trial"
            };
            characterController.ModelState.AddModelError("Name", "Required");
            //Act
            var badResponse = await characterController.Post(invalidCharacter);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public void Add_ValidObject_ReturnsCreatedResponse()
        {
            Random random = new Random();
            //Arrange
            var validCharacter = new CharacterDTO()
            {
                Name = random.ToString(),
                Planet = "Ziemia",
                Friends = new string[] {"R2-D2"},
                Episodes = new string[] {"EMPIRE"}
            };
         
            //Act
            var okResult = characterController.Post(validCharacter).Result;

            Assert.IsType<CreatedAtActionResult>(okResult.Result);     
        }

        [Fact]
        public async void Delete_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            //Arrange
            var notExistingNumber = 999;

            //Act
            var badResponse = await characterController.Delete(notExistingNumber);

            //Assert
            Assert.IsType<NotFoundResult>(badResponse.Result);
        }      

        [Fact]
        public async void Delete_ExistingLastItemOfCharacters_ReturnsEntity()
        {
            //Arrange
            var result = getContext().Characters.ToList().Last();
            var id = result.CharacterId;
            //Act
            var okResult = await characterController.Delete(id);
            //Assert
            Assert.IsType<CharacterDTO>(okResult.Value);
        }

    }
}
