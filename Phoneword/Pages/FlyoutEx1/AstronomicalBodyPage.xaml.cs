namespace Phoneword.Pages.FlyoutEx1;

[QueryProperty(nameof(AstroName), "astroName")]
public partial class AstronomicalBodyPage : ContentPage
{
	string astroName;
	public string AstroName
	{
		get => astroName;
		set
		{
			astroName = value;

			// this is a custom function to update the UI immediately
			UpdateAstroBodyUI(astroName);
		} 
	}

    public AstronomicalBodyPage()
    {
        InitializeComponent();
    }

    void UpdateAstroBodyUI(string astroName)
    {
        AstronomicalBody body = FindAstroData(astroName);

        Title = body.Name;

        lblIcon.Text = body.EmojiIcon;
        lblName.Text = body.Name;
        lblMass.Text = body.Mass;
        lblCircumference.Text = body.Circumference;
        lblAge.Text = body.Age;
    }

    AstronomicalBody FindAstroData(string astronomicalBodyName)
    {
        return astronomicalBodyName switch
        {
            "comet" => SolarSystemData.HalleysComet,
            "earth" => SolarSystemData.Earth,
            "moon" => SolarSystemData.Moon,
            "sun" => SolarSystemData.Sun,
            _ => throw new ArgumentException()
        };
    }
}

public class AstronomicalBody
{
    public string Name { get; set; }
    public string Mass { get; set; }
    public string Circumference { get; set; }
    public string Age { get; set; }
    public string EmojiIcon { get; set; }
}

public static class SolarSystemData
{
    public static AstronomicalBody Sun = new AstronomicalBody()
    {
        Name = "The Sun (Sol)",
        Mass = "1.9855*10^30 kg",
        Circumference = "4,379,000 km",
        Age = "4.57 billion years",
        EmojiIcon = "☀️",
    };

    public static AstronomicalBody Earth = new AstronomicalBody()
    {
        Name = "Earth",
        Mass = "5.97237*10^24 kg",
        Circumference = "40,075 km",
        Age = "4.54 billion years",
        EmojiIcon = "🌎",
    };

    public static AstronomicalBody Moon = new AstronomicalBody()
    {
        Name = "Moon",
        Mass = "7.342*10^22 kg",
        Circumference = "10,921 km",
        Age = "4.53 billion years",
        EmojiIcon = "🌕",
    };

    public static AstronomicalBody HalleysComet = new AstronomicalBody()
    {
        Name = "Halley's Comet",
        Mass = "22 * 10^14 kg",
        Circumference = "11 km",
        Age = "4.6 billion years",
        EmojiIcon = "☄",
    };
}