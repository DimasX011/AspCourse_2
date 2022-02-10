// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text;
using System.Text.Json;
using System.IO;

List<string> list = new List<string>();
string path = "test.txt";
FileInfo info = new FileInfo(path);


using (var client = new HttpClient())
{
    
    var tasks = new List<Task>();
    for (int i = 4; i < 14; i++)
    {
        var task = GetTask(i, client);
        tasks.Add(task);
    }
    await Task.WhenAll(tasks);
    
}

foreach(var c in list)
{
    File.AppendAllText(path, c);
    File.AppendAllText(path, Environment.NewLine);
    File.AppendAllText(path, Environment.NewLine);
}



    async Task GetTask(int count, HttpClient client)
    {
        if (client.BaseAddress == null)
        {
            client.BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com/");
        }
        var postResponce = await client.GetAsync($"posts/{count}");
        HttpContent httpContent = postResponce.Content;
        var json = await httpContent.ReadAsStringAsync();
        string hg = json.ToString();
        list.Add(hg);
    }




