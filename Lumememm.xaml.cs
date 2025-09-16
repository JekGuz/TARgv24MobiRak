using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace TARgv24;
public partial class Lumememm : ContentPage
{
    public Lumememm()
    {
        AbsoluteLayout taust;

        // Голова (круг)
        Frame pea = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 50,
        };

        Frame keha = new Frame
        {
            BackgroundColor = Colors.GhostWhite,
            CornerRadius = 90,
        };

        taust = new AbsoluteLayout { Children = { pea, keha } };
        Background = Colors.LightSkyBlue;

        AbsoluteLayout.SetLayoutBounds(pea, new Rect(0.5, 0.32, 100, 100));
        AbsoluteLayout.SetLayoutFlags(pea, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(keha, new Rect(0.5, 0.50, 180, 180));
        AbsoluteLayout.SetLayoutFlags(keha, AbsoluteLayoutFlags.PositionProportional);

        Content = taust;

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