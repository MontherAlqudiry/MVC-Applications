using Microsoft.AspNetCore.Mvc;

namespace DemoAPI_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoAPIController : ControllerBase
    {
       

        private readonly ILogger<DemoAPIController> _logger;

        public DemoAPIController(ILogger<DemoAPIController> logger)
        {
            _logger = logger;
        }



    }
}