using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class PatientInterfaceVM : BaseVM
    {
        public User User { get; set; }
        public Command SignOutCommand { get; set; }
        public Command ViewTestingHistoryCommand { get; set; }

        public PatientInterfaceVM()
        {
            User = new User();
            SignOutCommand = new Command(SignOutExecute);
            ViewTestingHistoryCommand = new Command(ViewTestingHistory);

        }

        private async void SignOutExecute(object obj)
        {
            App.User = null;
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void ViewTestingHistory(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewTestingHistory());
        }

        public string WelcomeLabel
        {
            get { return "Welcome to CTIS, Patient " + App.User.Name; }
            set
            {

            }
        }
    }
}
