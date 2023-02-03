using StatsApp.Controls;

namespace StatsApp.Views;

public partial class Games : ContentPage
{
	public Games()
	{
		InitializeComponent();

		List<string> list = new List<string>() { "Label1", "Label2", "Label3"};
		foreach (var item in list)
		{

			VSL.Add(new GameCard(new BCPlatformLib.MobileViewModels.GameViewModel()
			{
				Id = new Guid(),
				HomeTeam=item,
				AwayTeam="Celtics",
				Info="This is info",
				ScoresheetName="score.jpeg",
				Location="Ennistymon CC",
				_DateTime= DateTime.Now
			}));
		}
		
	}
}