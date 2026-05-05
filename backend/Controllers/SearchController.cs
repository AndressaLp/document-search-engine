using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("algorithms")]
        public IActionResult GetAlgorithms()
        {
            var algorithms = _searchService.GetAlgorithms();
            return Ok(algorithms);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] IFormFile file, [FromForm] string algorithm, [FromForm] string pattern)
        {
            if(file == null || file.Length == 0) return BadRequest("Arquivo inválido");

            string text;
            using(var reader = new StreamReader(file.OpenReadStream()))
            {
                text = await reader.ReadToEndAsync();
            }

            var result = _searchService.ExecuteSearch(text, pattern, algorithm);

            return Ok(result);
        }
    }
}