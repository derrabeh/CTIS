using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class OfficerInterfaceVM: BaseVM
    {
        public User User { get; set; }
        public Command SignOutCommand { get; set; }
        public Command RegisterTestCentreCommand { get; set; }
        public Command ManageTestKitCommand { get; set; }
        public Command GenerateTestReportCommand { get; set; }
        public Command RecordTesterCommand { get; set; }

        public OfficerInterfaceVM()
        {
            User = new User();
            SignOutCommand = new Command(SignOutExecute);
            RegisterTestCentreCommand = new Command(RegisterTestCentre);
            ManageTestKitCommand = new Command(ManageTestKit);
            GenerateTestReportCommand = new Command(GenerateTestReport);
            RecordTesterCommand = new Command(RecordTester);
        }

        private async void SignOutExecute(object obj)
        {
            App.User = null;
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void RegisterTestCentre(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddCentre());
        }

        private async void ManageTestKit(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ManageTestKit());
        }

        private async void GenerateTestReport(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GenerateTestReport());
        }

        private async void RecordTester(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddTester());
        }

        public string WelcomeLabel
        {
            get { return "Welcome to CTIS, officer " + App.User.Name; }
            set
            {
                
            }
        }
    }
}
