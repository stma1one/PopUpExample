using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PopUpExample.ViewModels;


namespace PopUpExample.Views

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }

        private async  void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have Been Alerted", "OK");
        }
    }
}
