using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class RegisterVM : BaseVM 
    {
        public User User { get; set; }

        public RegisterVM()
        {
            User = new User();
            LoginCommand = new Command(LoginExecute);
            SignUpCommand = new Command(SignUpExecute, CanSignUpExecute);
            User.Name = "Derra";
            User.Email = "derra@gmail.com";
            User.Password = "Password123";
            User.Passport = "A123456";
        }

        public string Name
        {
            get { return User.Name; }
            set
            {
                User.Name = value;
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
                SignUpCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
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

        public DateTime DOB
        {
            get { return User.DOB; }
            set
            {
                User.DOB = value;
                SignUpCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Passport
        {
            get { return User.Passport; }
            set
            {
                User.Passport = value;
                SignUpCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }

        private async void SignUpExecute(Object obj)
        {
            if (User.Password.Length < 9)
            {
                await Application.Current.MainPage.DisplayAlert("Register Error", "Your password must be more than 8 characters", "OK");
                return;
            }
            else if (!IsValidEmail(User.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Email", "Please enter a valid email address", "OK");
                return;
            }
            else if (User != null)
            {
                await FirebaseDBConnection.AddUserAsync(User);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async void LoginExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private bool CanSignUpExecute(object arg)
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

