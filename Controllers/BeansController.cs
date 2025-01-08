using Microsoft.AspNetCore.Mvc;
using AllTheBeansApp.Models;

namespace AllTheBeansApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeansController : ControllerBase
    {
        private readonly BeansRepository _beansRepository;

        public BeansController()
        {
            _beansRepository = new BeansRepository();
        }

        [HttpGet("price")]
        public IActionResult GetPrice(string name)
        {
            var price = _beansRepository.GetBeanCostPer100g(name);
            return Ok(new { price });
        }
    }
}
