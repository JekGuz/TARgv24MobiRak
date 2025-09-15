namespace TARgv24;
using Microsoft.Maui.Layouts;

public partial class DateTimePage : ContentPage
{
    Label mis_on_valitud;
    DatePicker datePicker;
    TimePicker timePicker;
    AbsoluteLayout al;
    public DateTimePage()
    {
        mis_on_valitud = new Label
        {
            Text = "Siin on kuvatakse valitud kuupäev või kellaaeg",
            FontSize = 40,
            TextColor = Colors.White,
            FontFamily = "Luismi Murder 400",
        };
        datePicker = new DatePicker 
        {
            FontSize = 40,
            TextColor = Colors.Black,
            FontFamily = "Luismi Murder 400",
            MinimumDate = DateTime.Now.AddDays(-7), // New DateTime (1000, 1, 1 )
            MaximumDate = new DateTime(2100, 12, 31),
            Date = DateTime.Now,
            Format = "D",
        };

        datePicker.DateSelected += Kuupaeva_valimine;
        al = new AbsoluteLayout { Children = { mis_on_valitud, datePicker } };
        AbsoluteLayout.SetLayoutBounds(mis_on_valitud, new Rect(0.5, 0.2, 0.9, 0.2));
        AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.All);
        Content = al;
    }

    private void Kuupaeva_valimine(object? sender, DateChangedEventArgs e)
    {
        mis_on_valitud.Text = $"Valisite kuupäev: {e.NewDate:D}";

    }
}