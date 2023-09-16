namespace Astronomy.Pages;

[QueryProperty(nameof(AstroName), "astroName")]
public sealed partial class AstronomicalBodyPage : ContentPage
{
    /// <summary>
    /// 
    /// </summary>
    private string _astroName;

    public string AstroName
    {
        get => _astroName;
        set
        {
            _astroName = value;

            // this is a custom function to update the UI immediately
            UpdateAstroBodyUi(_astroName);
        }
    }

    public AstronomicalBodyPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="astroName"></param>
    private void UpdateAstroBodyUi(string astroName)
    {
        var body = FindAstroData(astroName);

        Title = body.Name;

        lblIcon.Text = body.EmojiIcon;
        lblName.Text = body.Name;
        lblMass.Text = body.Mass;
        lblCircumference.Text = body.Circumference;
        lblAge.Text = body.Age;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="astronomicalBodyName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static AstronomicalBody FindAstroData(string astronomicalBodyName)
    {
        return astronomicalBodyName switch
        {
            "comet" => SolarSystemData.HalleysComet,
            "earth" => SolarSystemData.Earth,
            "moon" => SolarSystemData.Moon,
            "sun" => SolarSystemData.Sun,
            _ => throw new ArgumentException(),
        };
    }
}