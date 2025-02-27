using AnaliseSentimentoDeDadosIA.Entity;
using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Models;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Parameters;

namespace AnaliseSentimentoDeDadosIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentoController : ControllerBase
    {

        private readonly TextAnalyticsClient _textAnalyticsClient;

        public SentimentoController(TextAnalyticsClient textAnalyticsClient, TwitterClient twitterClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
            _twitterClient = twitterClient;
        }

      
        [HttpPost("{texto}")]
        public async  Task<ActionResult> GetSentimentoViaTexto(string texto) 
        {
            try
            {
                if (string.IsNullOrEmpty(texto)) return BadRequest("O texto não pode ser vazio");

                var resposta = await _textAnalyticsClient.AnalyzeSentimentAsync(texto);


                var sentimento = resposta.Value.Sentiment;

                return Ok(new 
                        { sentimento = sentimento });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
