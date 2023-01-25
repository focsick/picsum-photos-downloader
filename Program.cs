using System.Net;

int ask(string q)
{
    Console.Write(q);
    string r = Console.ReadLine();

    bool success = int.TryParse(r, out int number);

    if (success)
    {
        return number;
    }
    else
    {
        return ask(q);
    }
}

int w = ask("Ведите шерину изображения: ");
int h = ask("Ведите высота изображения: ");
var url = $"https://picsum.photos/{w}/{h}";
// Console.WriteLine(url);
var folder = "images";
Directory.CreateDirectory(folder);


using (var c = new WebClient())

{
    c.Headers.Add("User-Agent: Other");
    c.DownloadFile(url, Path.Combine(folder, $"{DateTime.Now.ToString("yyyy MM dd HH-mm-ss")}.jpg"));

}


