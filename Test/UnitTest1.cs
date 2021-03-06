using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTube.Controllers;
using Microsoft.AspNetCore.Mvc;
using YouTube.Models;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestUnit()
        {
            var controller = new HomeController();
            var result = await controller.Videos("trial bike");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Video>>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }
    }
}
