using StatsApp.Controls;
using System.Net;

namespace StatsApp.Views;

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
					RequestUri=new Uri("")
				});
			}
		}catch(Exception ex) 
		{
			Console.WriteLine(ex.Message);
		}		
	}
}