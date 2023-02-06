namespace StatsApp.Views;

using StatsApp.Controls;
using System.Net;
using Newtonsoft.Json;
using BCPlatformLib.MobileViewModels;

public partial class Games : ContentPage
{
	public Games()
	{
		InitializeComponent();

		try
		{
			using(HttpClient client = new())
			{
				var result = client.Send(new HttpRequestMessage()
				{
					Method = HttpMethod.Get,
					RequestUri=new Uri("http://192.168.1.101:5086/Api/Stats/AppGetGames")
				});
				foreach (var game in JsonConvert.DeserializeObject<List<GameViewModel>>(result.Content.ReadAsStringAsync().Result))
				{
					VSL.Add(new GameCard(game));
				}
			}
		}catch(Exception ex) 
		{
			Console.WriteLine(ex.Message);
		}		
	}
}