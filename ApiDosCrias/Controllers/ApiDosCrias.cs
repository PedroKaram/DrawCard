using Application;
using Microsoft.AspNetCore.Mvc;

namespace ApiDosCrias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiDosCrias : ControllerBase
    {

        private readonly Services service;

        private readonly ILogger<ApiDosCrias> _logger;

        public ApiDosCrias(ILogger<ApiDosCrias> logger)
        {
            _logger = logger;
            service = new Services();
        }

        [HttpGet]
        [Route("Shuffle")]
        public string Deck_Id()
        {
            var Task = service.RunAsync();
            var Deck = Task.Result;

            return string.Format("Deck Id: {0} \nRemaining: {1}", Deck.Deck_Id, Deck.Remaining);
        }

        [HttpGet]
        [Route("DrawCard")]
        public string NewCard()
        {
            var Task = service.RunDrawAsync();
            var Card =  Task.Result;

            return string.Format("Code: {0} \nValue: {1} \n Suit: {2}", Card.Code, Card.Value, Card.Suit);
        }

    }
}