using System.Threading.Tasks;

namespace TARgv24;

public partial class TimePage : ContentPage
{
	public TimePage()
	{
		InitializeComponent();
	}

    private async void Klil_pealdise_peal(object sender, TappedEventArgs e)
    {
		while (true) 
		{
			label.Text = DateTime.Now.ToString("HH:mm:ss");
			await Task.Delay(1000);
		}
    }
}