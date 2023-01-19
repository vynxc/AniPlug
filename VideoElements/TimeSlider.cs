using AniPlug.Converters;

namespace AniPlug;

public class TimeSlider : ContentView
{
    // Bindable property for the color of the PositionBox
    public static readonly BindableProperty PositionColorProperty =
        BindableProperty.Create(nameof(PositionColor), typeof(Color), typeof(TimeSlider), Color.FromHex("#BB86FC"));


    // Bindable property for the color of the PositionBox
    public static readonly BindableProperty BufferColorProperty =
        BindableProperty.Create(nameof(BufferColor), typeof(Color), typeof(TimeSlider), Color.FromHex("#03DAC6"));


    // Bindable property for the color of the BackBox
    public static readonly BindableProperty BackColorProperty =
        BindableProperty.Create(nameof(BackColor), typeof(Color), typeof(TimeSlider), Color.FromHex("#1E1E1E"));


    // Bindable property for the position of the slider
    public static readonly BindableProperty PositionProperty =
        BindableProperty.Create(nameof(Position), typeof(double), typeof(TimeSlider), 0.0);

    // Bindable property for the duration of the media
    public static readonly BindableProperty DurationProperty =
        BindableProperty.Create(nameof(Duration), typeof(double), typeof(TimeSlider), 0.0,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var timeSlider = (TimeSlider)bindable;
                timeSlider.Slider.Maximum = (double)newValue;
            });


    // Bindable property for the buffer duration of the media
    public static readonly BindableProperty BufferDurationProperty =
        BindableProperty.Create(nameof(BufferDuration), typeof(double), typeof(TimeSlider), 0.0);


    public TimeSlider()
    {
        // Initialize the elements in the TimeSlider control
        PositionBox = new BoxView
        {
            CornerRadius = 15,
            HeightRequest = 5,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        PositionBox.SetBinding(BoxView.ColorProperty, new Binding(nameof(PositionColor), source: this));
        PositionBox.SetBinding(WidthRequestProperty, new Binding(nameof(Position), source: this));
        BufferBox = new BoxView
        {
            CornerRadius = 15,
            HeightRequest = 3,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        BufferBox.SetBinding(WidthRequestProperty, new Binding(nameof(BufferDuration), source: this));
        BufferBox.SetBinding(BoxView.ColorProperty, new Binding(nameof(BufferColor), source: this));


        Slider = new Slider
        {
#if WINDOWS
                ThumbImageSource = ImageSource.FromFile("naruto.png"),
#else
            ThumbImageSource = ImageSource.FromFile("naruto.svg"),
#endif
            Maximum = Duration,
            BackgroundColor = Color.FromHex("#00000000"),
            HorizontalOptions = LayoutOptions.Fill,
            MaximumTrackColor = Color.FromHex("#00000000"),
            MinimumTrackColor = Color.FromHex("#00000000"),
            ThumbColor = Color.FromHex("#00000000"),
            VerticalOptions = LayoutOptions.Center
        };
        Back = new BoxView
        {
            CornerRadius = 15,
            HeightRequest = 2,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Center,
            Color = Color.FromHex("#FFA500")
        };


        var TimePos = new Label
        {
            HorizontalOptions = LayoutOptions.Start
        };
        TimePos.SetBinding(Label.TextProperty,
            new Binding(nameof(Position), converter: new MilisecondsToMinuteSecondConverter(), source: this));

        var TimeDur = new Label
        {
            HorizontalOptions = LayoutOptions.End
        };
        TimeDur.SetBinding(Label.TextProperty,
            new Binding(nameof(Duration), converter: new MilisecondsToMinuteSecondConverter(), source: this));
        Back.SetBinding(BoxView.ColorProperty, new Binding(nameof(BackColor), source: this));
        Slider.SetBinding(Slider.MaximumProperty, new Binding(nameof(Duration), source: this));
        Slider.SetBinding(Slider.ValueProperty, new Binding(nameof(Position), source: this));
        Slider.ValueChanged += UpdateSliderValues;
        // Add the elements to the TimeSlider control
        TimeSliderContainter = new Grid
        {
            Children =
            {
                Back,
                BufferBox,
                PositionBox,
                Slider
            }
        };
        TimeValueContainter = new Grid
        {
            Margin = new Thickness(10),
            Children =
            {
                TimePos,
                TimeDur
            }
        };

        Content = new StackLayout
        {
            Children =
            {
                TimeSliderContainter,
                TimeValueContainter
            }
        };
    }

    public Color PositionColor
    {
        get => (Color)GetValue(PositionColorProperty);
        set => SetValue(PositionColorProperty, value);
    }

    public Color BufferColor
    {
        get => (Color)GetValue(BufferColorProperty);
        set => SetValue(BufferColorProperty, value);
    }

    public Color BackColor
    {
        get => (Color)GetValue(BackColorProperty);
        set => SetValue(BackColorProperty, value);
    }

    public double Position
    {
        get => (double)GetValue(PositionProperty);
        set => SetValue(PositionProperty, value);
    }

    public double Duration
    {
        get => (double)GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public double BufferDuration
    {
        get => (double)GetValue(BufferDurationProperty);
        set => SetValue(BufferDurationProperty, value);
    }

    // Other elements in the TimeSlider control

    public Grid TimeSliderContainter { get; set; }
    public Grid TimeValueContainter { get; set; }

    public BoxView PositionBox { get; set; }
    public BoxView BufferBox { get; set; }
    public BoxView Back { get; set; }
    public Slider Slider { get; set; }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        PositionBox.WidthRequest = Width * Slider.Value / Duration;
        BufferBox.WidthRequest = Width * BufferDuration / Duration;
    }

    private void UpdateSliderValues(object sender, ValueChangedEventArgs e)
    {
        PositionBox.WidthRequest = Width * Slider.Value / Duration;
    }
}