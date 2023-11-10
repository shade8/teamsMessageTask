using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Core;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Azure.Identity;
class Program
{
    static async Task Main(string[] args)
    {
        string clientId = "10c9455c-8691-4a51-a28b-cb8308821669";
        string clientSecret = "Hkr8Q~iOaDBqyu5Ln.o0kyuzkY278D0UPQYS1a.w";
        string tenantId = "54df8ee5-42ab-4c14-b444-1b54f749b225"; 
        string teamId = "42d2fc2e-a622-4c7d-9eca-6183b5984a75"; 
        string channelId = "19%3Apw5EFYHAzvksB86UsuyTagHxsk_7UQHzHyoVu8Syngk1%40thread.tacv2"; 
        string messageText = "Hello from the Microsoft Graph API!";

        var scopes = new[] { "https://graph.microsoft.com/.default" };


       
        var options = new ClientSecretCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        };

        // https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
        var clientSecretCredential = new ClientSecretCredential(
            tenantId, clientId, clientSecret, options);

        var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

        try
        {
            var chatMessage = new ChatMessage
            {
                Body = new ItemBody
                {
                    Content = messageText,
                },
            };

            var result = await graphClient.Teams[teamId].Channels[channelId].Messages.PostAsync(chatMessage);

            Console.WriteLine("Message sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
