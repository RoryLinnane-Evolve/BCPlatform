

using BCPlatformLib.MobileViewModels;
using BCPlatformLib.Models;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using StatsApp.Controls;
using System.Data;

namespace StatsApp.Views;

public partial class Stats : ContentPage
{
	private HttpClient client;
	public Stats(Guid GameId)
	{

		client = new HttpClient();
		InitializeComponent();
		var results = client.Send(new HttpRequestMessage()
		{
			Method = HttpMethod.Get,
			RequestUri=new Uri($"http://192.168.1.101:5086/api/Stats/FromGame/{GameId}")
		});

		var statList = JsonConvert.DeserializeObject<List<StatlineViewModel>>(results.Content.ReadAsStringAsync().Result);
		foreach(var statline in statList)
		{
			VSL.Add(new StatlineRow(statline));
        }		
	}
}