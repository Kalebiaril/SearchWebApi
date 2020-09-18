using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchWebApi.DB;
using SearchWebApi.Interfaces;

namespace SearchWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchProvider _searchProvider;

        public SearchController(ILogger<SearchController> logger, ISearchProvider searchProvider)
        {
            _logger = logger;
            _searchProvider = searchProvider;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<SearchDataModel>>> Get([FromBody]string seachPhrase)
        {
            if (string.IsNullOrWhiteSpace(seachPhrase))
            {
                return BadRequest("No search phrase defined");
            }
            var result = await _searchProvider.SearchAsync(seachPhrase);
            if (result.Any())
            {
               
                return Ok(result);
            }
            return NotFound();
        }
    }
}
