using BCPlatformLib.Models;
using Microsoft.Maui.Controls.Shapes;
using Newtonsoft.Json;
using StatsApp.Views.Components;

namespace StatsApp.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        PostsStack.Clear();
        var Posts = new List<Post>();
        string s;
        using(HttpClient client = new HttpClient())
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, CONSTANTS.BaseURL+"/api/Posts");
            var response = client.SendAsync(message).Result;
            s = response.Content.ReadAsStringAsync().Result;
            Posts = JsonConvert.DeserializeObject<List<Post>>(s);
        }

        foreach(var post in Posts)
        {
            PostsStack.Add(
                new PostCard(post)
            );
        }
    }
}