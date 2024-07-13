using ATMApp.Interfaces;
using ATMApp.Models.DTOs;
using ATMApp.Models;
using ATMApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    
    public class CreateCardController : ControllerBase
    {
        private readonly ICardServices _cardServices;

        public CreateCardController(ICardServices cardServices)
        {
            _cardServices = cardServices;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Card>> CreateCard([FromBody] CardDTO cardDTO)
        {
            try
            {
                var result = await _cardServices.CreateCard(cardDTO);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
