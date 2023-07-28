namespace MyFirstApp;

public partial class MainPage : ContentPage
{
    string translatedNumber;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        Console.Write(enteredNumber);
        translatedNumber = Translator.ToNumber(enteredNumber);
        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.Text = "Call " + translatedNumber;
            CallButton.IsEnabled = true;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }
    private async void OnCall(object sender, EventArgs e) {
        if(await this.DisplayAlert("Dial a Number",
        "Would you like to call " + translatedNumber + "?",
        "Yes",
        "No")){
            try
            {
                if (PhoneDialer.Default.IsSupported)
                {
                    PhoneDialer.Default.Open(translatedNumber);
                }
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to Call", "Invalid Phone Number", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to Call", "Phone Dialing Failed", "OK");
            }
        }
    }

}


