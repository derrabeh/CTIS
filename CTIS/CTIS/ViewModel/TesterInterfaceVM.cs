using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class TesterInterfaceVM : BaseVM
    {
        public User User { get; set; }
        public Command SignOutCommand { get; set; }
        public Command RecordNewTestCommand { get; set; }
        public Command UpdateTestCommand { get; set; }
        public Command GenerateTestReportCommand { get; set; }

        public TesterInterfaceVM()
        {
            User = new User();
            SignOutCommand = new Command(SignOutExecute);
            RecordNewTestCommand = new Command(RecordNewTest);
            UpdateTestCommand = new Command(UpdateTest);
            GenerateTestReportCommand = new Command(GenerateTestReport);
        }

        private async void SignOutExecute(object obj)
        {
            App.User = null;
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void RecordNewTest(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RecordNewTest());
        }

        private async void UpdateTest(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UpdateTest());
        }

        private async void GenerateTestReport(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GenerateTestReport());
        }


        public string WelcomeLabel
        {
            get { return "Welcome to CTIS, tester " + App.User.Name; }
            set
            {

            }
        }
    }
}
