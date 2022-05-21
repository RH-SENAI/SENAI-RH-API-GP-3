using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.SentimentAnalisys
{
    public class SentimentAnalysis
    {
        private readonly AzureKeyCredential credentials = new("cb93c9f11c7f44c09d7bd3117ef5c5fe");
        private readonly Uri endpoint = new("https://ia-analise-de-sentimento-rhsenai.cognitiveservices.azure.com/");

        public DocumentSentiment AnalisarTexto(string texto)
        {

            TextAnalyticsClient textAnalyticsClient = new (endpoint, credentials);

            DocumentSentiment documentSentiment = textAnalyticsClient.AnalyzeSentiment(texto);

            return documentSentiment;
        }
    }
}