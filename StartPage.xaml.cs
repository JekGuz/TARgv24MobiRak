namespace TARgv24;

public partial class StartPage : ContentPage
{
	public List<ContentPage> lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new TimePage(), new DateTimePage(), new ValgusfoorPage(), new Lumememm() };
	public List<string> tekstid = new List<string>() { "Tee lahti leht Tekst-ga", "Figure leht", "Käivitamine timer", "DateTimePage", "Valgusfoor", "Lumememm" };
	ScrollView sv;
	VerticalStackLayout vsl;


	public StartPage()
	{
		InitializeComponent();
		Title = "Avaleht";
		vsl = new VerticalStackLayout {  };
		for (int i = 0; i < lehed.Count; i++) {
			Button nupp = new Button
			{
				Text = tekstid[i],
				FontSize = 40,
				BackgroundColor = Colors.Transparent,
				TextColor = Colors.LightGoldenrodYellow,
                FontAttributes = FontAttributes.Bold, //жирный шрифт
                CornerRadius = 20,
				FontFamily = "Luismi Murder 400",
				ZIndex = i
			};
			vsl.Add(nupp);
			nupp.Clicked += Nupp_Clicked;
		}
		sv = new ScrollView { Content = vsl };
        Content = sv;
    }
	private async void Nupp_Clicked (object? sender, EventArgs e)
	{
		Button nupp = (Button)sender;
		await Navigation.PushAsync(lehed[nupp.ZIndex]);
	}
}