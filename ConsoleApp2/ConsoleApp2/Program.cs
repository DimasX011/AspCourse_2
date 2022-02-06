// See https://aka.ms/new-console-template for more information

using System.Net;
using Newtonsoft.Json;

using (var client = new HttpClient())
{

    for (int i = 4; i < 14; i++)
    {
        await GetContent(i, client);
    }
};



static async Task GetContent(int id, HttpClient client)
{
    if (client.BaseAddress == null)
    {
        client.BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com/");
    }
    var postResponce = await client.GetAsync($"posts/{id}");
    Console.WriteLine(postResponce);
}