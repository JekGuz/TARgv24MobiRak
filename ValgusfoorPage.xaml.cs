
namespace TARgv24
{
    public partial class ValgusfoorPage : ContentPage
    {
        // Выключеный светофор
        Color offColor = Colors.DarkGray;
        public ValgusfoorPage()
        {
            var valgefoor_title = new Label
            {
                Text = "Valgefoor testimine",
                FontSize = 50,
                TextColor = Colors.Black,
                FontFamily = "Luismi Murder 400",
            };
            // Лампы
            var red = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                Color = offColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var yellow = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                Color = offColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var green = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                Color = offColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            // Кнопки вместе
            var vls = new VerticalStackLayout
            {
                Spacing = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { red, yellow, green }
            };

            // Корпус светофора (Frame)
            var korpus = new Frame
            {
                BackgroundColor = Colors.Black,
                BorderColor = Colors.Gray,
                CornerRadius = 24,
                Content = vls,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            // Кнопки внутрь
                Button sisse  = new Button
            {
                Text = "Sisse",
                FontSize = 40,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black,
                CornerRadius = 20,
                FontFamily = "Luismi Murder 400",
            };
            Button valju = new Button
            {
                Text = "Välja",
                FontSize = 40,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black,
                CornerRadius = 20,
                FontFamily = "Luismi Murder 400",
            };
            //обьединяем кнопки
            var hls = new HorizontalStackLayout
            {
                Spacing = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { sisse, valju }
            };


            // Content
            Content = new VerticalStackLayout
            {
                Spacing = 12,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                    {
                        valgefoor_title, // заголовок
                        korpus, // корпус светофора
                        hls // кнопки
                    }
            };

            // Задний фон и название
            Title = "Valgusfoor";
            BackgroundColor = Colors.White;
        }
    }
}