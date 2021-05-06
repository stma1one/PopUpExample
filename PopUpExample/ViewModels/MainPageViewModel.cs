using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace PopUpExample.ViewModels
{
    class MainPageViewModel:ViewModelBase
    {
        #region members
        
        private string message;
        #endregion
        #region Properties
        public string Message
        {
            get => message;
            set
            {
                if(value!=message)
                {
                    message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
           
            message = "no response recorded yet";

            SimplePopCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("ALERT", "You have been alerted", "OK"));

            GetResponsePopCommand = new Command(async () =>
            {
                bool res = await Application.Current.MainPage.DisplayAlert("Best Team Ever", "Is it Hapoel Holon?", "Yes", "No");
                if (res)
                    Message = "Hapoel Holon is the best";
                else
                    Message = "You are Wrong Hapoel Holon is the best";
            }
            );

            ActionSheetPopCommand = new Command(async () =>
            {
                Message = $"you chose to get notified by {  await Application.Current.MainPage.DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook")}";
            });

            ActionSheetPopWithDeleteCommand= new Command(async () =>
            {
                Message = $"you chose to  {  await Application.Current.MainPage.DisplayActionSheet("ActionSheet: Save file to?", "Cancel", "Delete", "Gallery", "Drive", "OneDrive")}";
            });

            PopGetPromptCommand = new Command(async () =>
            {
                Message = $"My Name is {await Application.Current.MainPage.DisplayPromptAsync("Question 1", "What's your name?")}";
            });

            PopDefineKeyboardCommand= new Command(async () =>
            {
                Message = $"You guessed {await Application.Current.MainPage.DisplayPromptAsync("Question 2", "How Many fingers am i holding?", initialValue: "5", maxLength: 2, keyboard: Keyboard.Numeric)} fingers";
            });
        }
        
        #endregion

        #region Commands
        public ICommand SimplePopCommand { get; set; }
        public ICommand GetResponsePopCommand { get; set; }

        public ICommand ActionSheetPopCommand { get; set; }

        public ICommand ActionSheetPopWithDeleteCommand { get; set; }
        public ICommand PopGetPromptCommand { get; set; }

        public ICommand PopDefineKeyboardCommand { get; set; }
        #endregion
    }
}
