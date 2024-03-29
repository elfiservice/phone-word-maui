﻿namespace Phoneword;

public partial class MainPage : ContentPage
{

	public const double MyFontSize = 28; // note: A const value is static

	public MainPage()
	{
		InitializeComponent();
		CallButton.Clicked += OnCallClicked;
	}

	string translatedNumber;

	private void OnTranslateClicked(object sender, EventArgs e)
	{
		string enteredNumber = PhoneNumberText.Text;
		translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Call " + translatedNumber;
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";
		}
	}

	async void OnCallClicked(object sender, EventArgs e)
	{
		if (await this.DisplayAlert(
			"Dial a Number",
			"Would you like to call " + translatedNumber + "?",
			"Yes",
			"No"))
		{
			// TODO: dial the phone
			try
			{
				if (PhoneDialer.Default.IsSupported)
					PhoneDialer.Default.Open(translatedNumber);
			}
			catch (ArgumentNullException)
			{
				await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
			}
			catch (Exception)
			{
				// Other error has occurred.
				await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
			}
		}
	}
}

// https://learn.microsoft.com/en-us/training/modules/create-user-interface-xaml/6-xaml-markup-extensions
public class GlobalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return MainPage.MyFontSize;
    }
}

[ContentProperty ("Member")]
public class StaticExtension : IMarkupExtension
{
    public string Member {get; set;}
    public object ProvideValue (IServiceProvider serviceProvider)
    {
        return MainPage.MyFontSize;
    }
}