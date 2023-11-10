using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var adaptiveCardJson = @"{
          ""type"": ""message"",
          ""attachments"": [
            {
              ""contentType"": ""application/vnd.microsoft.card.adaptive"",
              ""content"": {
                ""type"": ""AdaptiveCard"",
                ""body"": [
                  {
                    ""type"": ""TextBlock"",
                    ""text"": ""Message Text""
                  }
                ],
                ""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",
                ""version"": ""1.0""
              }
            }
          ]
        }";

        var webhookUrl = "https://kwixee.webhook.office.com/webhookb2/42d2fc2e-a622-4c7d-9eca-6183b5984a75@54df8ee5-42ab-4c14-b444-1b54f749b225/IncomingWebhook/c4bebf569aad441f8a8b8352a1287a99/cae09b64-7e11-4646-a484-cd76cf4d135d";

        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(adaptiveCardJson, System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(webhookUrl, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Message sent successfully.");
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}
