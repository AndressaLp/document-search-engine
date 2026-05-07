using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
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

        private static readonly ActivitySource ActivitySource = new("DocumentSearchActivity");

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

        [HttpPost("upload")]
        public async Task<IActionResult> Search([FromForm] IFormFile file, [FromForm] string algorithm, [FromForm] string pattern)
        {
            using var activity = ActivitySource.StartActivity("Search Request");

            if(file == null || file.Length == 0) return BadRequest("Arquivo inválido");

            string text;
            using (ActivitySource.StartActivity("Read File"))
            using(var reader = new StreamReader(file.OpenReadStream()))
            {
                text = await reader.ReadToEndAsync();
            }

            SearchResult result;
            using (ActivitySource.StartActivity("Execute Algorithm"))
            {
                result = _searchService.ExecuteSearch(text, pattern, algorithm);    
            }

            using (ActivitySource.StartActivity("Format Response"))
            {
                return Ok(result);    
            }
        }
    }
}