namespace MyMauiApp;

public partial class MainPage : ContentPage
{
    private string _translatedNumber;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTranslate(object sender, EventArgs e)
    {
        var enteredNumber = PhoneNumberText.Text;
        _translatedNumber = PhoneWordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(_translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + _translatedNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    private async void OnCall(object sender, EventArgs e)
    {
        if (await DisplayAlert(
                "Dial a Number",
                "Would you like to call " + _translatedNumber + "?",
                "Yes",
                "No"))
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(_translatedNumber);
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