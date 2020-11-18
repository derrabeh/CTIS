using CTIS.Model;
using CTIS.Utilities;
using System;
using Xamarin.Forms;
using System.Net.Mail;

namespace CTIS.ViewModel
{
    public class AddTesterVM : BaseVM
    {
        public User User { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command BackCommand { get; set; }

        public AddTesterVM()
        {
            User = new User();
            SaveCommand = new Command(SaveExecute, CanSaveExecute);
            BackCommand = new Command(BackExecute);
            CancelCommand = new Command(CancelExecute);
        }

        private async void BackExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void CancelExecute(Object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Cancel Confirmation", "No tester will be added. Are you sure?", "Yes", "No");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void SaveExecute(Object obj)
        {
            if (User.Password.Length < 9)
            {
                await Application.Current.MainPage.DisplayAlert("Register Error", "Password must be more than 8 characters", "OK");
                return;
            }
            else if (!IsValidEmail(User.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Email", "Please enter a valid email address", "OK");
                return;
            }
            else if (User != null)
            {
                await FirebaseDBConnection.AddTesterAsync(User);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public string Name
        {
            get { return User.Name; }
            set
            {
                User.Name = value;
                SaveCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                SaveCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return User.Email; }
            set
            {
                User.Email = value;
                SaveCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public DateTime DOB
        {
            get { return User.DOB; }
            set
            {
                User.DOB = value;
                SaveCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Passport
        {
            get { return User.Passport; }
            set
            {
                User.Passport = value;
                SaveCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
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

        private bool CanSaveExecute(object arg)
        {
            if (!string.IsNullOrWhiteSpace(User.Email) &&
                !string.IsNullOrWhiteSpace(User.Password))
            {
                return true;
            }
            return false;
        }
    }
}
