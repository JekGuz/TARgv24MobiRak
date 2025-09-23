namespace TARgv24;
using Microsoft.Maui.Layouts;

public partial class DateTimePage : ContentPage
{
    Label mis_on_valitud;
    DatePicker datePicker;
    TimePicker timePicker;
    Picker picker;
    Slider slider; // Плавно регулирует
    Stepper stepper; // Пошагово
    AbsoluteLayout al;
    public DateTimePage()
    {
        mis_on_valitud = new Label
        {
            Text = "Siin kuvatakse valitud kuupäev/kellaaeg",
            FontSize = 30,
            TextColor = Colors.RoyalBlue,    // Поменяла на другой цвет
            FontFamily = "Luismi Murder 400",
        };

        datePicker = new DatePicker
        {
            FontSize = 30,
            TextColor = Colors.Black,
            FontFamily = "Luismi Murder 400",
            MinimumDate = DateTime.Now.AddDays(-7), // New DateTime (1000, 1, 1 )
            MaximumDate = new DateTime(2100, 12, 31),
            Date = DateTime.Now,
            Format = "D",
        };

        datePicker.DateSelected += Kuupaeva_valimine;

        timePicker = new TimePicker
        {
            FontSize = 30,
            TextColor = Colors.Black,
            FontFamily = "Luismi Murder 400",
            Time = new TimeSpan(12, 0, 0),
            Format = "T",
        };
        timePicker.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                mis_on_valitud.Text = $"Valisite kelleaja: {timePicker.Time}";
            }
        };

        picker = new Picker
        {
            Title = "Vali üks",
            FontSize = 30,
            FontFamily = "Luismi Murder 400",
            TextColor = Colors.Black,
            //ItemsSource = new List<string> { "Üks", "Kaks", "Kolm", "Neli", "Viis", "Kuus", "Seitse", "Kaheksa", "Üheksa", "Kuume", "Üksteist", "Kaksteist" }
            ItemsSource = new List<string> { "Teade", "ja/ei teade", "Valik", "Vaba vastus", "Viis" }

            };

        //picker.Items.Add("Kuus");
        //picker.ItemsSource.Add("Kuus");
        picker.SelectedIndexChanged += (s, e) =>
        {
            if (picker.SelectedIndex != -1)
            {
                mis_on_valitud.Text = $"Valitud on: {picker.Items[picker.SelectedIndex]}";
                if (picker.SelectedIndex == 0)
                {
                    DisplayAlert("Teade", "Meil on hea uudis!", "Selge");
                }
                else if (picker.SelectedIndex == 1)
                {
                    DisplayAlert("Küsimus", "Kas soovite jätkata?", "Jah", "Ei");
                }
                else if (picker.SelectedIndex == 2)
                {
                    var valik = new string[] { "Valik 1", "Valik 2", "Valik 3" };
                    var tulemus = DisplayActionSheet("Palun vali", "Katkesta", null, valik);
                }
                else if (picker.SelectedIndex == 3)
                {
                    var tulemus = DisplayPromptAsync("Küsimus", "Sissesta oma vasus", "OK", "Katkesta", "Siia tuleb vastus", -1, Keyboard.Text, "Vastus");
                }
            }
        };

        slider = new Slider
        {
            Minimum = 0,
            Maximum = 360,
            Value = 40,
            ThumbColor = Colors.DarkBlue,
            MinimumTrackColor = Colors.MistyRose,
            MaximumTrackColor = Colors.BlueViolet,
        };

        slider.ValueChanged += (s, e) =>
        {
            mis_on_valitud.FontSize = e.NewValue;
            mis_on_valitud.Rotation = e.NewValue;
        };

        stepper = new Stepper
        {
            Minimum = 0,
            Maximum = 100,
            Increment = 1,
            Value = 20,
            HorizontalOptions = LayoutOptions.Center,
        };

        stepper.ValueChanged += (s, e) =>
        {
            mis_on_valitud.Text = $"Stepper value: {e.NewValue}";
        };

        al = new AbsoluteLayout { Children = { mis_on_valitud, datePicker, timePicker, picker, slider, stepper } };

        //AbsoluteLayout.SetLayoutBounds(mis_on_valitud, new Rect(0.5, 0.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.PositionProportional);

        //AbsoluteLayout.SetLayoutBounds(datePicker, new Rect(0.5, 0.2, 0.9, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

        //AbsoluteLayout.SetLayoutBounds(timePicker, new Rect(0.5, 0.4, 0.9, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

        //AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.5, 0.6, 0.9, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(piker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

        //AbsoluteLayout.SetLayoutBounds(slider, new Rect(0.5, 0.8, 0.9, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

        //AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.5, 1, 0.9, AbsoluteLayout.AutoSize));
        ////AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

        var elementid = new View[]
        {
            mis_on_valitud, datePicker, timePicker, picker, slider, stepper
        };
        for (int i = 0; i < elementid.Length; i++)
        {
            AbsoluteLayout.SetLayoutBounds(elementid[i], new Rect(0.5, i * 0.2, 0.9, 0.15));
            AbsoluteLayout.SetLayoutFlags(elementid[i], AbsoluteLayoutFlags.All);
            //AbsoluteLayout.SetLayoutFlags(elementid[i], AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        }
        Content = al;
    }
    private void Kuupaeva_valimine(object? sender, DateChangedEventArgs e)
    {
        mis_on_valitud.Text = $"Valisite kuupäev: {e.NewDate:D}";

    }
}