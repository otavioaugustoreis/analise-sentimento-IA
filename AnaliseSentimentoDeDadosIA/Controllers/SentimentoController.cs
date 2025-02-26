using AnaliseSentimentoDeDadosIA.Entity;
using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Models;

namespace AnaliseSentimentoDeDadosIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentoController : ControllerBase
    {

        private readonly TextAnalyticsClient _textAnalyticsClient;
        private readonly TwitterClient _twitterClient;

        public SentimentoController(TextAnalyticsClient textAnalyticsClient, TwitterClient twitterClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
            _twitterClient = twitterClient;
        }

        [HttpPost("twitter/{username}")]
        public async Task<ActionResult<SentimentoEntity>> GetSentimentoViaTwitter([FromBody] string username)
        {
            try
            {
                var userTimeline = await _twitterClient.Timelines.GetUserTimelineAsync(username);
                
                var list = new List<dynamic>();


                foreach (var tweet in userTimeline)
                {
                    var sentimentResponse = await _textAnalyticsClient.AnalyzeSentimentAsync(tweet.Text);
                    var sentiment = sentimentResponse.Value.Sentiment;

                    list.Add(new
                    {
                        Text = tweet.Text,
                        Sentiment = sentiment.ToString()
                    });
                }

                return Ok(list);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async  Task<ActionResult<SentimentoEntity>> GetSentimentoViaTexto([FromBody] string texto) 
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
