using System.Net.Sockets;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;


namespace TARgv24;
public partial class Lumememm : ContentPage
{
    Frame pea, keha;
    BoxView amber, amber2, sall1, sall2;
    Border silm1, silm2, kasi1, kasi2, nupp1, nupp2, nupp3;
    GraphicsView nina;

    View[] tervalumememm; // будущий масив со всеми частятми

    Random rnd = new Random();
    Color[] colors = { Colors.GhostWhite, Colors.LightYellow, Colors.LightPink, Colors.LightGreen, Colors.LightBlue, Colors.MintCream, Colors.Aqua, Colors.LightCoral, Colors.LightSalmon };

    public Lumememm()
    {
        AbsoluteLayout taust;

        // Ведро
        amber = new BoxView
        {
            Color = Colors.SaddleBrown
        };

        amber2 = new BoxView
        {
            Color = Colors.SaddleBrown
        };

        // Голова (круг)
        pea = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 50,
            HasShadow = false // Убираем тени
        };

        // Глаза (круг)
        silm1 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,  // Это толщина обводки (рамки) у элемента Border
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) } //StrokeShape задаёт форму рамки/заливки, RoundRectangle — это прямоугольник со скруглёнными углами, CornerRadius = new CornerRadius(10) — радиус скругления углов (10 пикселей).
        };

        silm2 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        // Нос нарисон ниже в канве
        nina = new GraphicsView
        {
            Drawable = new ninajoonis()
        };


        // Шарф
        sall1 = new BoxView
        {
            Color = Colors.Red
        };

        sall2 = new BoxView
        {
            Color = Colors.Red
        };

        // Тело (круг)
        keha = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 90,
            HasShadow = false // Убираем тени
        };

        kasi1 = new Border
        {
            Background = Colors.SaddleBrown,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(7) }, // Закругления
            StrokeThickness = 0, // Рамка не рисуется, остаётся только заливка
            Rotation = -40 // Поворот
        };

        kasi2 = new Border
        {
            Background = Colors.SaddleBrown,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(7) },
            StrokeThickness = 0,
            Rotation = 40
        };

        nupp1 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        nupp2 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        nupp3 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        tervalumememm = new View[]
        {
            pea,
            keha,
            amber,
            amber2,
            silm1,
            silm2,
            sall1,
            sall2,
            kasi1,
            kasi2,
            nupp1,
            nupp2,
            nupp3,
            nina
        };

        // Кнопки ---------------------------------------------------------------------------------------------------------------------
        Button NaitaPeida = new Button
        {
            Text = "Peida", // начальное состояние — показываем снеговика
            FontSize = 40,
            BackgroundColor = Colors.DarkBlue,
            TextColor = Colors.GhostWhite,
            CornerRadius = 20,
            FontFamily = "Luismi Murder 400",
        };

        NaitaPeida.Clicked += (s, e) =>
        {
            if (NaitaPeida.Text == "Peida")
            {
                // прячем снеговика
                foreach (var v in tervalumememm)
                    v.IsVisible = false;

                NaitaPeida.Text = "Näita"; // меняем надпись
            }
            else
            {
                // показываем снеговика
                foreach (var v in tervalumememm)
                    v.IsVisible = true;

                NaitaPeida.Text = "Peida"; // меняем обратно
            }
        };

        Button varvi = new Button
        {
            Text = "Muuta Värv",
            FontSize = 40,
            BackgroundColor = Colors.DarkBlue,
            TextColor = Colors.GhostWhite,
            CornerRadius = 20,
            FontFamily = "Luismi Murder 400",
        };

        varvi.Clicked += varvi_Clicked;

        Slider sulata = new Slider
        {
            Minimum = 0,   // начальное значение (0 = нормальный снеговик)
            Maximum = 1,   // конечное значение (1 = растаял)
            Value = 0,     // стартовая позиция
            ThumbColor = Colors.DarkBlue,
            MinimumTrackColor = Colors.LightBlue,
            MaximumTrackColor = Colors.Gray
        };

        sulata.ValueChanged += (s, e) =>
        {
            double progress = e.NewValue; // от 0 до 1

            foreach (var v in tervalumememm)
            {
                // уменьшаем размер
                v.Scale = 1 - 0.5 * progress;   // от 1 до 0.5
                                                // смещаем вниз
                v.TranslationY = 60 * progress; // от 0 до 60
                                                // делаем прозрачнее
                v.Opacity = 1 - progress;       // от 1 до 0
            }
        };


        Button tansi = new Button
        {
            Text = "Tansi",
            FontSize = 40,
            BackgroundColor = Colors.DarkBlue,
            TextColor = Colors.GhostWhite,
            CornerRadius = 20,
            FontFamily = "Luismi Murder 400",
        };

        tansi.Clicked += tansi_Clicked;

        Button lahtesta = new Button
        {
            Text = "Lähtesta",
            FontSize = 40,
            BackgroundColor = Colors.LightCoral,
            TextColor = Colors.GhostWhite,
            CornerRadius = 20,
            FontFamily = "Luismi Murder 400",
        };

        lahtesta.Clicked += lahtesta_Clicked;

        //Label nuppud = new Label
        //{
        //    Text = "Toimingunupud",
        //    FontFamily = "Luismi Murder 400",
        //    FontSize = 40,
        //    FontAttributes = FontAttributes.Bold,
        //    TextColor = Colors.DarkBlue,
        //    HorizontalTextAlignment = TextAlignment.Center,
        //    VerticalTextAlignment = TextAlignment.Center,
        //};

        Frame panel1 = new Frame
        {
            BackgroundColor = Colors.Transparent,
            Padding = new Thickness(12, 10),
            CornerRadius = 16,
            HasShadow = true,
            Content = new HorizontalStackLayout
            {
                Spacing = 10,
                Children = { NaitaPeida, varvi, tansi }
            }
        };

        Frame panel2 = new Frame
        {
            BackgroundColor = Colors.Transparent,
            Padding = new Thickness(12, 10),
            CornerRadius = 16,
            HasShadow = true,
            Content = new HorizontalStackLayout
            {
                Spacing = 10,
                Children = { lahtesta }
            }
        };


        taust = new AbsoluteLayout { Children = { amber, amber2, silm1, silm2, pea, sall1, sall2, nina, keha, kasi1, kasi2, nupp1, nupp2, nupp3, sulata } };
        Background = Colors.LightSkyBlue;

        AbsoluteLayout.SetLayoutBounds(amber, new Rect(0.5, 0.20, 60, 80));
        AbsoluteLayout.SetLayoutFlags(amber, AbsoluteLayoutFlags.PositionProportional);
        amber.ZIndex = 3; // поверх головы
        // Порядок наложения элементов задаётся порядком добавления в Children (не вышло, тени убираем) или через ZIndex

        AbsoluteLayout.SetLayoutBounds(amber2, new Rect(0.5, 0.28, 100, 14));
        AbsoluteLayout.SetLayoutFlags(amber2, AbsoluteLayoutFlags.PositionProportional);
        amber2.ZIndex = 4;

        AbsoluteLayout.SetLayoutBounds(pea, new Rect(0.5, 0.32, 100, 100));
        AbsoluteLayout.SetLayoutFlags(pea, AbsoluteLayoutFlags.PositionProportional);
        pea.ZIndex = 2;

        AbsoluteLayout.SetLayoutBounds(sall1, new Rect(0.5, 0.38, 120, 20));
        AbsoluteLayout.SetLayoutFlags(sall1, AbsoluteLayoutFlags.PositionProportional);
        sall1.ZIndex = 7;

        AbsoluteLayout.SetLayoutBounds(sall2, new Rect(0.55, 0.42, 20, 60));
        AbsoluteLayout.SetLayoutFlags(sall2, AbsoluteLayoutFlags.PositionProportional);
        sall2.ZIndex = 7;

        AbsoluteLayout.SetLayoutBounds(nina, new Rect(0.55, 0.32, 50, 30));
        AbsoluteLayout.SetLayoutFlags(nina, AbsoluteLayoutFlags.PositionProportional);
        nina.ZIndex = 8;

        AbsoluteLayout.SetLayoutBounds(silm1, new Rect(0.45, 0.32, 10, 10));
        AbsoluteLayout.SetLayoutFlags(silm1, AbsoluteLayoutFlags.PositionProportional);
        silm1.ZIndex = 5;

        AbsoluteLayout.SetLayoutBounds(silm2, new Rect(0.55, 0.32, 10, 10));
        AbsoluteLayout.SetLayoutFlags(silm2, AbsoluteLayoutFlags.PositionProportional);
        silm2.ZIndex = 5;

        AbsoluteLayout.SetLayoutBounds(keha, new Rect(0.5, 0.5, 180, 180));
        AbsoluteLayout.SetLayoutFlags(keha, AbsoluteLayoutFlags.PositionProportional);
        keha.ZIndex = 1;

        AbsoluteLayout.SetLayoutBounds(kasi1, new Rect(0.15, 0.47, 100, 14));
        AbsoluteLayout.SetLayoutFlags(kasi1, AbsoluteLayoutFlags.PositionProportional);
        kasi1.ZIndex = 9;

        AbsoluteLayout.SetLayoutBounds(kasi2, new Rect(0.85, 0.47, 100, 14));
        AbsoluteLayout.SetLayoutFlags(kasi2, AbsoluteLayoutFlags.PositionProportional);
        kasi2.ZIndex = 9;

        AbsoluteLayout.SetLayoutBounds(nupp2, new Rect(0.5, 0.45, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp2, AbsoluteLayoutFlags.PositionProportional);
        nupp2.ZIndex = 6;

        AbsoluteLayout.SetLayoutBounds(nupp1, new Rect(0.5, 0.50, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp1, AbsoluteLayoutFlags.PositionProportional);
        nupp1.ZIndex = 6;

        AbsoluteLayout.SetLayoutBounds(nupp3, new Rect(0.5, 0.55, 10, 10));
        AbsoluteLayout.SetLayoutFlags(nupp3, AbsoluteLayoutFlags.PositionProportional);
        nupp3.ZIndex = 6;

        //AbsoluteLayout.SetLayoutBounds(nuppud, new Rect(0.5, 0.65, 1.0, 90));
        //AbsoluteLayout.SetLayoutFlags(nuppud, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        //nuppud.ZIndex = 19;


        AbsoluteLayout.SetLayoutBounds(panel1, new Rect(0.5, 0.70, 1.0, 90));
        AbsoluteLayout.SetLayoutFlags(panel1, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        panel1.ZIndex = 20;

        AbsoluteLayout.SetLayoutBounds(sulata, new Rect(0.5, 0.90, 1.0, 200));
        AbsoluteLayout.SetLayoutFlags(sulata, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        sulata.ZIndex = 21;

        AbsoluteLayout.SetLayoutBounds(panel2, new Rect(0.5, 0.95, 1.0, 90));
        AbsoluteLayout.SetLayoutFlags(panel2, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        panel2.ZIndex = 20;

        taust.Children.Add(panel1);
        taust.Children.Add(panel2);
        Content = taust;

    }


    // ---------------------------------------------------------- НОС рисуем в канве ------------------------------------------------------------
    public class ninajoonis : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect) // dirtyRect — прямоугольник, в пределах которого происходит рисование
        {
            canvas.Antialias = true; // Сглажевание
            canvas.FillColor = Colors.Orange;

            PathF path = new PathF();
            path.MoveTo(0, 15); // Первая точка
            path.LineTo(70, 20); // Вторая точка (кончик носа вправо)
            path.LineTo(0, 40); // Третья точка (нижняя часть у головы)
            path.Close();

            canvas.FillPath(path); // Заливаем получившийся треугольник цветом
        }
    }

    // ------------------------------------------------------Функции-----------------------------------------------------------------
    private void peida_Clicked(object sender, EventArgs e)
    {
        foreach (var v in tervalumememm)
            v.IsVisible = false;

        //pea.IsVisible = false;
        //keha.IsVisible = false;
        //amber.IsVisible = false;
        //amber2.IsVisible = false;
        //silm1.IsVisible = false;
        //silm2.IsVisible = false;
        //sall1.IsVisible = false;
        //sall2.IsVisible = false;
        //kasi1.IsVisible = false;
        //kasi2.IsVisible = false;
        //nupp1.IsVisible = false;
        //nupp2.IsVisible = false;
        //nupp3.IsVisible = false;
        //nina.IsVisible = false;
    }
    private void naita_Clicked(object sender, EventArgs e)
    {
        foreach (var v in tervalumememm)
            v.IsVisible = true;
    }

    private void varvi_Clicked(object sender, EventArgs e)
    {
        var randomColor = colors[rnd.Next(colors.Length)];
        pea.BackgroundColor = randomColor;
        keha.BackgroundColor = randomColor;
    }

    ////private void suluta_Clickes(object sender, EventArgs e)
    ////{
    ////    foreach (var v in tervalumememm)
    ////    {
    ////        // v.ScaleTo(2.0, 3000, Easing.CubicInOut); // Очень понравилось!
    ////        v.ScaleTo(0.5, 3000, Easing.CubicInOut); // Изменяет масштаб элемента (увеличивает или уменьшает).
    ////        v.TranslateTo(0, 60, 3000, Easing.CubicInOut); // Перемещает элемент по осям X и Y, easing → тип движения (ускорение/замедление).
    ////        v.FadeTo(0, 3000, Easing.CubicIn); // Изменяет прозрачность элемента, easing → кривая плавности.
    ////    }
    ////}

    private async void tansi_Clicked(object sender, EventArgs e)
    {
        {
            // шаг влево + наклон влево
            foreach (var v in tervalumememm)
            {
                v.TranslateTo(-20, v.TranslationY, 500, Easing.SinInOut);
                v.RotateTo(-15, 500, Easing.SinInOut);
            }

            // через 600 мс — вправо
            Device.StartTimer(TimeSpan.FromMilliseconds(600), () =>
            {
                foreach (var v in tervalumememm)
                {
                    v.TranslateTo(20, v.TranslationY, 500, Easing.SinInOut);
                    v.RotateTo(15, 500, Easing.SinInOut);
                }
                return false; // один раз
            });

            // ещё через 600 мс — вернуть в центр
            Device.StartTimer(TimeSpan.FromMilliseconds(1200), () =>
            {
                foreach (var v in tervalumememm)
                {
                    v.TranslateTo(0, v.TranslationY, 500, Easing.SinInOut);
                    v.RotateTo(0, 500, Easing.SinInOut);
                }
                return false;
            });

            // Ржала в голос
            ////foreach (var v in tervalumememm)
            ////{
            ////    await v.TranslateTo(-20, v.TranslationY, 500, Easing.SinInOut);
            ////    await v.RotateTo(-15, 500, Easing.SinInOut);
            ////}

            ////foreach (var v in tervalumememm)
            ////{
            ////    await v.TranslateTo(20, v.TranslationY, 500, Easing.SinInOut);
            ////    await v.RotateTo(15, 500, Easing.SinInOut);
            ////}

            ////foreach (var v in tervalumememm)
            ////{
            ////    await v.TranslateTo(0, v.TranslationY, 500, Easing.SinInOut);
            ////    await v.RotateTo(0, 500, Easing.SinInOut);
            ////}
        }
    }


    private void lahtesta_Clicked(object sender, EventArgs e)
    {
        foreach (var v in tervalumememm)
        {
            // показываем все части
            v.IsVisible = true;

            // сбрасываем трансформации
            v.TranslationX = 0;
            v.TranslationY = 0;
            v.Rotation = 0;
            v.Scale = 1;
            v.Opacity = 1;
        }

        // возвращаем базовые цвета
        pea.BackgroundColor = Colors.GhostWhite;
        keha.BackgroundColor = Colors.GhostWhite;
        sall1.Color = Colors.Red;
        sall2.Color = Colors.Red;
        amber.Color = Colors.SaddleBrown;
        amber2.Color = Colors.SaddleBrown;
        kasi1.Background = Colors.SaddleBrown;
        kasi2.Background = Colors.SaddleBrown;
        silm1.Background = Colors.Black;
        silm2.Background = Colors.Black;
        nupp1.Background = Colors.Black;
        nupp2.Background = Colors.Black;
        nupp3.Background = Colors.Black;
    }

}






//public partial class Lumememm : ContentPage
//{
//	Random random = new Random();
//	AbsoluteLayout taust;
//	public Lumememm()
//	{
//		AbsoluteLayout taust = new AbsoluteLayout()
//		{
//			//BackgroundColor = Color.FromRgb(10, 10, 100),
//			Background = Colors.LightSkyBlue,
//		};

//        Grid tahvel = new Grid();
//		{
//			BackgroundColor = Colors.Transparent;
//        };

//		//taust.Children.Add( tahvel );
//		tahvel.GestureRecognizers.Add(new GestureRecognizer()
//		{
//			Command = new Command<Point>(Point =>
//			{
//				var lumi = new Image()
//				{
//					Source = "snow.png",
//					HeightRequest = random.Next(5, 50),
//					WidthRequest = random.Next(5, 50),
//				};
//				AbsoluteLayout.SetLayoutBounds(lumi, new Rect(pont.x, pont.y, WidthRequest,HeightRequest));
//				AbsoluteLayout.SetLayoutFlags(lumi, AbsoluteLayoutFlags.None);
//				taust.Children.Add(lumi);
//			});
//			NumberOfTapRequestred = 2
//		});
//		Content = taust;
//	}    

//}