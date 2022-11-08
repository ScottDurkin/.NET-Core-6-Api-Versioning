using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//https://www.telerik.com/blogs/your-guide-rest-api-versioning-aspnet-core
namespace ApiVersionTest.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class BandsController : ControllerBase
    {

        public class BandV1
        {
            public int Id { get; set; }
            public String Name { get; set; }

        }
        public class BandV2
        {
            public int Id { get; set; }
            public String Names { get; set; }

        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BandV1> bands = new List<BandV1> { new BandV1 { Id = 4, Name = "Durkins" }, new BandV1 { Id = 5, Name = "Gurkins" }, };

            return new JsonResult(bands);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BandV1 band = new BandV1();
            band.Id = 4;
            band.Name = "Durkins";

            return new JsonResult(band);
        }






        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetAllV2()
        {
            List<BandV2> bands = new List<BandV2> { new BandV2 { Id = 2, Names = "Greenday" }, new BandV2 { Id = 3, Names = "Slipknot" }, new BandV2 { Id = 4, Names = "A7X" } };

            return new JsonResult(bands);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get2(int id)
        {
            BandV2 band = new BandV2();
            band.Id = id;
            band.Names = "Durkins";

            return new JsonResult(band);
        }
    }
}
