namespace TARgv24;

public partial class TextPage : ContentPage
{
	Label LblTekst;
	Editor editorTekst;
	HorizontalStackLayout hsl;
	public TextPage()
	{
		LblTekst = new Label
		{
			Text = "Tekst: ",
			FontSize = 20,
			TextColor = Colors.Black,
			FontFamily = "Luismi Murder 400"
		};
		editorTekst = new Editor
        {
            Text = "Siia saad kirjutada",
            FontSize = 22,
            TextColor = Color.FromRgb(0, 0, 100),
            HeightRequest = 300,
            Margin = new Thickness(20),
            FontFamily = "Luckily 400",
            AutoSize = EditorAutoSizeOption.TextChanges,
            Placeholder = "Kirjuta siia oma mõtted",
            FontAttributes = FontAttributes.Italic
        };
        editorTekst.TextChanged += EditorTekst_TextChanger;
        hsl = new HorizontalStackLayout
        {
            BackgroundColor = Color.FromRgb(120, 30, 50),
            Children = { LblTekst, editorTekst },
            HorizontalOptions = LayoutOptions.Center,
        };
        Content = hsl;
    }

    private void EditorTekst_TextChanger(object? sender, TextChangedEventArgs e)
    {
        LblTekst.Text = editorTekst.Text;
    }
}