using System.Threading.Tasks;

namespace TARgv24;

public partial class TimePage : ContentPage
{
	public TimePage()
	{
		InitializeComponent();
	}

	bool on_off = true;
    private async void Klil_pealdise_peal(object sender, TappedEventArgs e)
    {
        if (on_off) { on_off = false; }
        else 
        {  
            on_off = true;
            Naita_aeg();
        }
    }
	private async void Naita_aeg()
	{
        while (on_off)
        {
            label.Text = DateTime.Now.ToString("HH:mm:ss");
            await Task.Delay(1000);
        }
    }
}