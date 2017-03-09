using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        public MainPage()
        {
            InitializeComponent();

            this.Padding = new Thickness(20,
            Device.OnPlatform<double>(40, 20, 20), 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
            };

            panel.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN",
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });

            translateButton.Clicked += OnTranslate;

            this.Content = panel;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            string translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}
