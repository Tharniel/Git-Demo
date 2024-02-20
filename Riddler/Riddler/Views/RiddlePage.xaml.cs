using System.Net;
using System.Xml.Linq;

namespace Riddler.Views;

public partial class RiddlePage : ContentPage
{
	public RiddlePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.RiddlePageViewModel();
    }

    private async void OnClickedGetRiddle(object sender, EventArgs e)
    {
        var riddle = ((ListView)sender).SelectedItem as Models.Riddle;
        if (riddle != null)
        {
            var riddles = new Views.RiddelDetailsPage();
            riddles.BindingContext = riddle;
            await Navigation.PushAsync(riddles);

        }
    }
}