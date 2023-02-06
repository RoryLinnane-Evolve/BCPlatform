using BCPlatformLib.MobileViewModels;

namespace StatsApp.Controls;

public partial class StatlineRow : ContentView
{
	private StatlineViewModel viewModel;
	public StatlineRow(StatlineViewModel model)
	{
		InitializeComponent();
		viewModel = model;
		BindGrid(viewModel);
	}
	public void BindGrid(StatlineViewModel model)
	{
        PlayerName.Text = model.PlayerName;
        Number.Text = model.Number.ToString();
        Pts.Text = model.Pts.ToString();
        Reb.Text = model.Reb.ToString();
        Ast.Text = model.Ast.ToString();
        Blk.Text = model.Blk.ToString();
        Stl.Text = model.Stl.ToString();
    }

    private void PtsPlus_Clicked(object sender, EventArgs e)
    {
        viewModel.Pts++;
        BindGrid(viewModel);
    }

    private void PtsMinus_Clicked(object sender, EventArgs e)
    {
        viewModel.Pts--;
        BindGrid(viewModel);
    }

    private void RebPlus_Clicked(object sender, EventArgs e)
    {
        viewModel.Reb++;
        BindGrid(viewModel);
    }

    private void RebMinus_Clicked(object sender, EventArgs e)
    {
        viewModel.Reb--;
        BindGrid(viewModel);
    }

    private void AstPlus_Clicked(object sender, EventArgs e)
    {
        viewModel.Ast++;
        BindGrid(viewModel);
    }

    private void AstMinus_Clicked(object sender, EventArgs e)
    {
        viewModel.Ast--;
        BindGrid(viewModel);
    }

    private void BlkPlus_Clicked(object sender, EventArgs e)
    {
        viewModel.Blk++;
        BindGrid(viewModel);
    }

    private void BlkMinus_Clicked(object sender, EventArgs e)
    {
        viewModel.Blk--;
        BindGrid(viewModel);
    }

    private void StlPlus_Clicked(object sender, EventArgs e)
    {
        viewModel.Stl++;
        BindGrid(viewModel);
    }

    private void StlMinus_Clicked(object sender, EventArgs e)
    {
        viewModel.Stl--;
        BindGrid(viewModel);
    }
}