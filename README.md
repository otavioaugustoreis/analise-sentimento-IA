# API de Análise de Sentimentos com IA do Azure

Este projeto é uma API desenvolvida em ASP.NET Core que utiliza a IA do Azure (Cognitive Services - Text Analytics) para analisar o sentimento de textos. A API recebe um texto como entrada e retorna se o sentimento é positivo, negativo ou neutro, juntamente com a confiança da análise.

## Pré-requisitos

Antes de começar, você precisará dos seguintes itens:

1. **.NET SDK**: Certifique-se de ter o .NET SDK instalado. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download).
2. **Conta no Azure**: Crie uma conta gratuita no [Azure](https://azure.microsoft.com/).
3. **Serviço de Text Analytics no Azure**:
   - Acesse o [Portal do Azure](https://portal.azure.com/).
   - Crie um recurso do **Text Analytics**.
   - Anote a **chave de API** e o **endpoint** do serviço, pois serão necessários para configurar a API.
