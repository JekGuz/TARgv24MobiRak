using System.Net.Sockets;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;


namespace TARgv24;
public partial class Lumememm : ContentPage
{
    public Lumememm()
    {
        AbsoluteLayout taust;

        // Ведро
        BoxView amber = new BoxView
        {
            Color = Colors.SaddleBrown
        };

        BoxView amber2 = new BoxView
        {
            Color = Colors.SaddleBrown
        };

        // Голова (круг)
        Frame pea = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 50,
            HasShadow = false // Убираем тени
        };

        // Глаза (круг)
        Border silm1 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,  // Это толщина обводки (рамки) у элемента Border
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) } //StrokeShape задаёт форму рамки/заливки, RoundRectangle — это прямоугольник со скруглёнными углами, CornerRadius = new CornerRadius(10) — радиус скругления углов (10 пикселей).
        };

        Border silm2 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        // Нос нарисон ниже в канве
        GraphicsView nina = new GraphicsView
        {
            Drawable = new ninajoonis()
        };


        // Шарф
        BoxView sall1 = new BoxView 
        { 
            Color = Colors.Red 
        };

        BoxView sall2 = new BoxView 
        { 
            Color = Colors.Red 
        };

        // Тело (круг)
        Frame keha = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 90,
            HasShadow = false // Убираем тени
        };

        Border kasi1 = new Border
        {
            Background = Colors.SaddleBrown,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(7) }, // Закругления
            StrokeThickness = 0, // Рамка не рисуется, остаётся только заливка
            Rotation = -30 // Поворот
        };

        Border kasi2 = new Border
        {
            Background = Colors.SaddleBrown,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(7) },
            StrokeThickness = 0,
            Rotation = 30
        };

        Border nupp1 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        Border nupp2 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        Border nupp3 = new Border
        {
            Background = Colors.Black,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) }
        };

        taust = new AbsoluteLayout { Children = { amber, amber2, silm1, silm2 ,pea, sall1, sall2, nina, keha, kasi1, kasi2, nupp1, nupp2, nupp3 } };
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