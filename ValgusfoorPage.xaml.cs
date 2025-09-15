
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

        // Лайбел для надписей
        private Label redText;
        private Label yellowText;
        private Label greenText;
        private Label ooText;


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

            // Под светофором label
            //var redLabel = new Label 
            //{ 
            //    Text = "Seisa", 
            //    FontSize = 20, 
            //    TextColor = Colors.White, 
            //    HorizontalTextAlignment = TextAlignment.Center 
            //}; 
            //var redStack = new VerticalStackLayout 
            //{ 
            //    Spacing = 4, 
            //    HorizontalOptions = LayoutOptions.Center, 
            //    Children = { redLamp, redLabel } 
            //};

            redText = new Label
            {
                Text = "Seisa",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = false //Скрывем, чтобы в нужный момент открыть
            };

            var redGrid = new Grid //это контейнер, который умеет «накладывать» элементы друг на друга или раскладывать их в таблицу (строки и колонки).
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Children = { redLamp, redText } // текст поверх круга
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

            yellowText = new Label
            {
                Text = "Valmista",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };

            ooText = new Label
            {
                Text = "Kontrolli",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };

            var yellowGrid = new Grid
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Children = { yellowLamp, yellowText, ooText }
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

            greenText = new Label
            {
                Text = "Sõida",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };

            var greenGrid = new Grid
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Children = { greenLamp, greenText }
            };

            // Светофор вместе
            var vls = new VerticalStackLayout
            {
                Spacing = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { redGrid, yellowGrid, greenGrid }
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
                    redText.IsVisible = true; // Делаем видимым
                    yellowText.IsVisible = false; // Невидимо
                    ooText.IsVisible = false; // Невидимо
                    greenText.IsVisible = false; // Невидимо
                    await Task.Delay(OnLight);
                    if (tootab == false) break;

                    // жёлтый
                    redLamp.Color = offColor;
                    yellowLamp.Color = Colors.Yellow;
                    greenLamp.Color = offColor;
                    redText.IsVisible = false;
                    yellowText.IsVisible = true; // Делаем видимым
                    ooText.IsVisible = false;
                    greenText.IsVisible = false;
                    await Task.Delay(OnLight);
                    if (tootab == false) break;

                    // зелёный
                    redLamp.Color = offColor;
                    yellowLamp.Color = offColor;
                    greenLamp.Color = Colors.Green;
                    redText.IsVisible = false;
                    yellowText.IsVisible = false;
                    ooText.IsVisible = false;
                    greenText.IsVisible = true; // Делаем видимым
                    await Task.Delay(OnLight);
                    // Повторяется
                }
                else
                {
                    // Ночной режим
                    redLamp.Color = offColor;
                    greenLamp.Color = offColor;
                    yellowLamp.Color = Colors.Yellow;
                    redText.IsVisible = false;
                    yellowText.IsVisible = false;
                    ooText.IsVisible = true; // Делаем видимым
                    greenText.IsVisible = false;
        
                    await Task.Delay(NightOn);
                    if (tootab == false) break;

                    yellowLamp.Color = offColor;
                    ooText.IsVisible = false;
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
            redText.IsVisible = false;
            yellowText.IsVisible = false;
            ooText.IsVisible= false;
            greenText.IsVisible = false;
        }
    }
}