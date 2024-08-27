using System.Text;
using HtmlAgilityPack;

var html = new HtmlWeb().Load("https://scryfall.com/sets/akh");
var links = html.DocumentNode.SelectNodes("/html/body/div[3]/div[2]/div/div/a[1]");

Parallel.ForEach(links, link =>
{
    var htmlCard = new HtmlWeb().Load(link?.GetAttributes().ElementAt(1).Value);
    var tituloCard = htmlCard.DocumentNode.SelectSingleNode("/html/body/div[3]/div[1]/div/div[3]/h1/span[1]");
    var descriptionCard = htmlCard.DocumentNode.SelectSingleNode("/html/body/div[3]/div[1]/div/div[3]/div[1]/div/p[2]");
    var descriptionCard_2 =
        htmlCard.DocumentNode.SelectSingleNode("/html/body/div[3]/div[1]/div/div[3]/div[1]/div[1]/p");

    if (tituloCard != null && descriptionCard != null)
    {
        Console.WriteLine("| NAME: " + tituloCard.InnerText.Trim());
        Console.WriteLine(descriptionCard.InnerText);
        Console.WriteLine("----------------------------------------");
    }

    if (descriptionCard_2 != null && descriptionCard == null)
    {
        Console.WriteLine("NAME: " + tituloCard.InnerText.Trim());
        Console.WriteLine(descriptionCard_2.InnerText);
        Console.WriteLine("----------------------------------------");
    }
});