using SklepSportowy.Controllers;
using SklepSportowy.Services;
using SklepSportowy.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SklepSportowy_test
{
    public class SprzetControllerTest
    {
        private SprzetSportowyApiController controller;
        private ISprzetSportowyService service;

        public SprzetControllerTest()
        {
            service = new SprzetSportowyServiceTest();
            controller = new SprzetSportowyApiController(service);
        }

        [Fact]
        public void Get()
        {
            IEnumerable<SprzetSportowy> sprzet = controller.Get();
            Assert.IsType<List<SprzetSportowy>>(sprzet);
            Assert.Equal(sprzet.Count<SprzetSportowy>(), 1);
        }

        [Theory]
        [InlineData(1)]
        public void GetById(int id)
        {
            var task = controller.Get(id);
            SprzetSportowy sprzet = Assert.IsType<SprzetSportowy>(task.Value);
            Assert.Equal(sprzet.Id, service.FindByRelations(id).Id);
        }

        [Fact]
        public void Post()
        {
            SprzetSportowy sprzet = new SprzetSportowy() { Id = 2, NazwaSprzetu = "Koszulka", ModelSprzetu = "IK6", Cena = 200, Firmy = new List<Firma>(), Promocje = new List<Promocja>() };
            var task = controller.Post(sprzet);
            Assert.IsType<CreatedResult>(task.Result);
        }

        [Fact]
        public void Put()
        {
            SprzetSportowy sprzet = new SprzetSportowy()
            {
                Id = 1,
                NazwaSprzetu = "Koszulka_change",
                ModelSprzetu = "IK6",
                Cena = 150,
                Firmy = new List<Firma>(),
                Promocje = new List<Promocja>()
            };

            var task = controller.Put(sprzet);
            Assert.IsType<OkObjectResult>(task.Result);
        }

        [Theory]
        [InlineData(1)]
        public void DeleteForExisting(int id)
        {
            var task = controller.Delete(id);
            Assert.IsType<NoContentResult>(task.Result);
        }
    }
}