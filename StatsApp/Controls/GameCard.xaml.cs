using BCPlatformLib.MobileViewModels;
using StatsApp.Views;

namespace StatsApp.Controls;
public partial class GameCard : ContentView
{
	public BindableProperty Model;
	public Guid GameId;
	public GameCard(GameViewModel game)
	{
        //lblHomeTeam.Text = game.HomeTeam;
        //lblAwayTeam.Text = game.AwayTeam;
        //GameId= game.Id;
        InitializeComponent();
	}

    private void Edit_Clicked(object sender, EventArgs e)
    {
		var s = new Stats(GameId);
    }
}