// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.Documents.Client;

Console.WriteLine("Hello, World!");

var uri = @"https://localhost:8081";
var key = @"C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
var databaseName = "DWX";
var collectionName = "Errors";


var client = new DocumentClient(new Uri(uri), key);
var uriFactory = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
var feedOptions = new FeedOptions { MaxItemCount = -1 };

try
{
    var feed = await client.ReadDocumentFeedAsync(uriFactory, feedOptions);

    foreach (var document in feed)
    {
        Console.WriteLine(document);
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}