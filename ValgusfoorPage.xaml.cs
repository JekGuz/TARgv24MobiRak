
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace TARgv24
{
    public partial class ValgusfoorPage : ContentPage
    {
        // Выключеный светофор
        Color offColor = Colors.DarkGray;

        // Поля чтобы удобно было обрашаться к цветам
        private BoxView redLamp;
        private BoxView yellowLamp;
        private BoxView greenLamp;

        // Управление циклом
        private bool tootab = false;
        private bool ooMode = false;

        // Тайминги
        private const int OnLight = 1500; // Для всего светофора
        private const int NightOn = 700; // Для ночного режима гореть желтый будет
        private const int NightOff = 500; // Пауза эмитация мигания


        public ValgusfoorPage()
        {
            var valgefoor_title = new Label
            {
                Text = "Valgefoor testimine",
                FontSize = 50,
                TextColor = Colors.Black,
                FontFamily = "Luismi Murder 400",
                HorizontalTextAlignment = TextAlignment.Center
            };
            // Лампы
            redLamp = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                Color = offColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            yellowLamp = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                Color = offColor,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            greenLamp = new BoxView
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
                Children = { redLamp, yellowLamp, greenLamp } // Изменяем на мои лампы
            };

            // Корпус светофора (Frame)
            var korpus = new Frame
            {
                BackgroundColor = Colors.Black,
                BorderColor = Colors.Gray,
                CornerRadius = 24,
                Content = vls,
                Padding = 16,
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

            sisse.Clicked += Sisse_Clicked;

            Button oo = new Button
            {
                Text = "Öörežiim",
                FontSize = 40,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black,
                CornerRadius = 20,
                FontFamily = "Luismi Murder 400",
            };

            oo.Clicked += Oo_Clicked;


            Button valju = new Button
            {
                Text = "Välja",
                FontSize = 40,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black,
                CornerRadius = 20,
                FontFamily = "Luismi Murder 400",
            };

            valju.Clicked += Valja_Clicked;

            //обьединяем кнопки
            var hls = new HorizontalStackLayout
            {
                Spacing = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { sisse, oo, valju }
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
        // ------------------------------------------------------ Обработчика кнопок и логика (т.к теряю)-----------------

        private async void Sisse_Clicked(object sender, EventArgs e)
        {
            ooMode = false; // Дневной режим
            if (tootab) return;
            tootab = true;
            await RunCycleAsync();
        }

        private async void Oo_Clicked(object? sender, EventArgs e)
        {
            ooMode = true; // Ночной режим
            if (tootab) return;
            tootab = true;
            await RunCycleAsync();
        }

        private void Valja_Clicked(object sender, EventArgs e)
        {
            tootab = false; //Выкл
            AllOff();
        }

        private async Task RunCycleAsync()
        {
            while (tootab)
            {
                if (ooMode == false)
                {
                    // Дневной режим
                    // красный
                    redLamp.Color = Colors.Red;
                    yellowLamp.Color = offColor;
                    greenLamp.Color = offColor;
                    await Task.Delay(OnLight);
                    if (tootab == false) break;

                    // жёлтый
                    redLamp.Color = offColor;
                    yellowLamp.Color = Colors.Yellow;
                    greenLamp.Color = offColor;
                    await Task.Delay(OnLight);
                    if (tootab == false) break;

                    // зелёный
                    redLamp.Color = offColor;
                    yellowLamp.Color = offColor;
                    greenLamp.Color = Colors.Green;
                    await Task.Delay(OnLight);
                    // Повторяется
                }
                else
                {
                    // Ночной режим
                    redLamp.Color = offColor;
                    greenLamp.Color = offColor;

                    yellowLamp.Color = Colors.Yellow;
                    await Task.Delay(NightOn);
                    if (tootab == false) break;

                    yellowLamp.Color = offColor;
                    await Task.Delay(NightOff);
                    //Повторяется
                }
            }
        }


        private void AllOff()
        {
            redLamp.Color = offColor;
            yellowLamp.Color = offColor;
            greenLamp.Color = offColor;
        }
    }
}