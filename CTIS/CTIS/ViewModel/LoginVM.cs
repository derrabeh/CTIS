using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    public class LoginVM : BaseVM
    {
        public User User { get; set; }
        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }

        public LoginVM()
        {
            User = new User();
            User.Email = "manager@gmail.com";
            User.Password = "password123";
            LoginCommand = new Command(LoginExecute, CanLoginExecute);
            SignUpCommand = new Command(SignUpExecute);
        }

        public string Email
        {
            get { return User.Email; }
            set
            {
                User.Email = value;
                SignUpCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                LoginCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private async void LoginExecute(Object obj)
        {
            User user = await FirebaseDBConnection.GetUserAsync(User);
            if (user != null)
            {
                App.User = user;
                Application.Current.MainPage = new NavigationPage(new GenerateTestReport());
            }
            else if (!IsValidEmail(User.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Email", "Please enter a valid email address", "OK");
                return;
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Login Error", "Can't find user with matching email and password", "OK");
                return;
            }
        }

        private async void SignUpExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private bool CanLoginExecute(object arg)
        {
            if (!string.IsNullOrWhiteSpace(User.Email) &&
                !string.IsNullOrWhiteSpace(User.Password))
            {
                return true;
            }
            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
