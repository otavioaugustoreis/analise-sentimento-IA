using AnaliseSentimentoDeDadosIA.Entity;
using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseSentimentoDeDadosIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentoController : ControllerBase
    {

        private readonly TextAnalyticsClient _textAnalyticsClient;

        public SentimentoController(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        [HttpPost]
        public async  Task<ActionResult<SentimentoEntity>> GetSentimento([FromBody] string texto) 
        {
            try
            {
                if (string.IsNullOrEmpty(texto)) return BadRequest("O texto não pode ser vazio");

                var resposta = await _textAnalyticsClient.AnalyzeSentimentAsync(texto);


                var sentimento = resposta.Value.Sentiment;

                return Ok(new { sentimento = resposta.Value.Sentiment.ToString()});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
