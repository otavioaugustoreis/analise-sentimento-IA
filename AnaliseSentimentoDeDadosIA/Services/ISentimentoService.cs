using AnaliseSentimentoDeDadosIA.Entity;

namespace AnaliseSentimentoDeDadosIA.Services
{
    public interface ISentimentoService
    {


        public SentimentoEntity Get(string texto);
    }
}
