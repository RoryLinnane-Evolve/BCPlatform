using BCPlatformLib.MobileViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using StatsApp.Views;

namespace StatsApp.Controls;
public partial class GameCard : ContentView
{
	public BindableProperty Model;
	public Guid GameId;
	public GameCard(GameViewModel game)
	{
        InitializeComponent();
        lblHomeTeam.Text = game.HomeTeam;
        lblAwayTeam.Text = game.AwayTeam;
        GameId=game.Id;
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Stats(GameId));
    }
}