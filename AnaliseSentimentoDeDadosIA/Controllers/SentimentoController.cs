using AnaliseSentimentoDeDadosIA.Entity;
using AnaliseSentimentoDeDadosIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseSentimentoDeDadosIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentoController : ControllerBase
    {

        private readonly ISentimentoService _sentimentoService;

        public SentimentoController(ISentimentoService sentimentoService)
        {
            _sentimentoService = sentimentoService;
        }

        [HttpGet]
        public ActionResult<SentimentoEntity> GetSentimento([FromBody] string texto) 
        {
            return Ok(new { SentimentoEntity = "Positivo" });
        }

    }
}
