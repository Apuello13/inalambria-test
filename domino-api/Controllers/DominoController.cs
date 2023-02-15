using Microsoft.AspNetCore.Mvc;
using domino_api.Models;
using domino_api.Utilities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace domino_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DominoController : ControllerBase
    {
        // POST api/<DominoController>
        [HttpPost]
        public IActionResult Post([FromBody] List<int[]> numbers)
        {
            List<Domino> dominos = Utils.convertDominosToObject(numbers);
            if (Utils.isValidLengthDominos(dominos))
                return BadRequest(MessageError.NOT_VALID_LENGTH);
            if (Utils.isValidChainDomino(dominos))
                return BadRequest(MessageError.INVALID_DOMINOS);
            List<List<Domino>> combinations = Utils.generateCombinations(dominos, numbers);
            return Ok(combinations);
        }
    }
}
