using BCPlatformLib.Models;

namespace StatsApp.Views.Components;

public partial class PostCard : ContentView
{
	public PostCard(Post post)
	{
		InitializeComponent();
		Title.Text = post.Title;
		Description.Text = post.Description;
		var displayPhoto = post.ImageNames.Split(',')[0];
		string src = CONSTANTS.BaseURL + "/Images/Posts/" + displayPhoto;
		DisplayPhoto.Source = src;
    }
}