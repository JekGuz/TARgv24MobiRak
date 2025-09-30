
using SkiaSharp;

namespace TARgv24;

public partial class PuslePage : ContentPage
{
    private const int Rows = 3;
    private const int Columns = 4;
    Grid sourcegrid, targetgrid;
    Dictionary<string, Image> pieceImages = new Dictionary<string, Image>();
    Dictionary<(int row, int col), string> correctPositions = new();
    Image image, img;

    public PuslePage()
    {
        Title = "Pusle leht";
        BackgroundImageSource = "taust.png";
        var mainLayout = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(10)
        };

        Button newGame = new Button
        {
            Text = "Alusta uut mängu",
            FontSize = 20,
            BackgroundColor = Colors.LightBlue,
            TextColor = Color.FromRgb(4, 48, 61),
            CornerRadius = 5,
            BorderColor = Color.FromRgb(37, 186, 199),
            BorderWidth = 2,
            Margin = 10,
            FontFamily = "Kanit-MediumItalic"
        };

        newGame.Clicked += OnNewGameClicked;

        Button pickImage = new Button
        {
            Text = "Vali pilt",
            FontSize = 20,
            BackgroundColor = Colors.LightGreen,
            TextColor = Color.FromRgb(4, 48, 61),
            CornerRadius = 5,
            BorderColor = Color.FromRgb(37, 186, 199),
            BorderWidth = 2,
            Margin = 10,
            FontFamily = "Kanit-MediumItalic"
        };

        pickImage.Clicked += async (s, e) => await PickImageAsync();

        image = new Image
        {
            Source = "dotnet_bot.png",
            WidthRequest = 200,
            HeightRequest = 200
        };

        sourcegrid = new Grid
        {
            BackgroundColor = Colors.LightGray,
            HeightRequest = 200,
            WidthRequest = 200
        };

        targetgrid = new Grid
        {
            BackgroundColor = Colors.Aquamarine
        };

        for (int r = 0; r < Rows; r++)
        {
            sourcegrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            targetgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        }
        for (int c = 0; c < Columns; c++)
        {
            sourcegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            targetgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        mainLayout.Children.Add(new HorizontalStackLayout
        {
            Spacing = 40,
            Children = { newGame, pickImage, image }
        });

        mainLayout.Children.Add(sourcegrid);
        mainLayout.Children.Add(targetgrid);

        InitializePieces();
        Content = mainLayout;
    }

    private void InitializePieces()
    {
        pieceImages.Clear();
        correctPositions.Clear();
        sourcegrid.Children.Clear();
        targetgrid.Children.Clear();
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                string id = $"piece_{r}_{c}";
                var pieceImage = new Image
                {
                    Source = $"{id}.png",
                    WidthRequest = 100,
                    HeightRequest = 100
                };

                AddPiedesGasteres(img, id); // Lisame pildi zestid
                pieceImages[id] = img;
                correctPositions[(r, c)] = id;
            }
        }
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                var target = new Border
                {
                    BackgroundColor = Colors.White,
                    Stroke = Colors.Black,
                    StrokeThickness = 2,
                    Margin = 5,
                    WidthRequest = 100,
                    HeightRequest = 100
                };

            }
        }
    }

    private void AddPiedesGasteres(Image img, string id)
    {
        //Drag and drop
        img.GestureRecognizers.Add(new DragGestureRecognizer
        {
            CanDrag = true,
            DragStartingCommand = new Command<DragStartingEventArgs>(args =>
            { args.Data.Properties["id"] = id; })
        });
    }
    private async Task PickImageAsync()
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Vali pilt pusle jaoks",
            FileTypes = FilePickerFileType.Images,
        });
        string filePath;
        if (result != null)
        {
            filePath = result.FullPath;
            //return;
        }
        else
        {
            filePath = "dotnet_bot.png";
            //return;
        }
        image.Source = ImageSource.FromFile(filePath);
        var pieces = SplitImage(filePath, Rows, Columns);
        pieceImages.Clear();
        correctPositions.Clear();
        int index = 0;
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                string id = $"piece_{r}_{c}";
                var img = new Image
                {
                    Source = pieces[index],
                    WidthRequest = 100,
                    HeightRequest = 100,
                };
                AddPiedesGasteres(img, id); //Lisame pildi zestid
                pieceImages[id] = img;
                correctPositions[(r, c)] = id;
                index++;

            }

        }
    }

    private static List<ImageSource> SplitImage(string filePath, int rows, int columns)
    {
        var result = new List<ImageSource>();
        using var input = File.OpenRead(filePath);
        using var bitmap = SKBitmap.Decode(input);
        int pieceWidth = bitmap.Width / columns;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                var rect = new SKRectI(c * pieceWidth, r * pieceWidth, (c + 1) * pieceWidth, (r + 1) * pieceWidth);
                using var piece = new SKBitmap(rect.Width, rect.Height);
                using (var canvas = new SKCanvas(piece))
                {
                    canvas.DrawBitmap(bitmap, rect, new SKRect(0, 0, rect.Width, rect.Height));
                }
                using var image = SKImage.FromBitmap(piece);
                using var data = image.Encode(SKEncodedImageFormat.Png, 100);
                var bytes = data.ToArray();
                result.Add(ImageSource.FromStream(() => new MemoryStream(bytes)));
            }
        }
        return result;
    }

    private void OnNewGameClicked(object sender, EventArgs e)
    {
        // TODO: Implement new game logic
    }
}
