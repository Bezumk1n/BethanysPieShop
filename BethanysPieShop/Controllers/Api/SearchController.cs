using BethanysPieShop.Models;
using BethanysPieShop.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies();
            return Ok(allPies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie is null) return NotFound();
            return Ok(pie);
        }
        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuerry)
        {
            IEnumerable<Pie> pies = Enumerable.Empty<Pie>();
            if(!string.IsNullOrWhiteSpace(searchQuerry))
                pies = _pieRepository.SearchPies(searchQuerry).ToArray();
            return new JsonResult(pies);
        }
    }
}
