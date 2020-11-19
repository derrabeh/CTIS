using CTIS.Model;
using CTIS.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class AddCentreVM : BaseVM
    {
        public TestCentre TestCentre { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }

        public AddCentreVM()
        {
            TestCentre = new TestCentre();
            SaveCommand = new Command(SaveExecute);
            CancelCommand = new Command(CancelExecute);
        }

        public static bool IsValidPhoneNum(string telNo)
        {
            return Regex.Match(telNo, @"^\+\d{1,9}$").Success;
        }

        private async void CancelExecute(Object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Cancel Confirmation", "Your input will not be saved. Are you sure?", "Yes", "No");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void SaveExecute(Object obj)
        {
            if (string.IsNullOrWhiteSpace(TestCentre.CentreName))
            {
                await Application.Current.MainPage.DisplayAlert("Missing field", "Centre name cannot be empty.", "OK");
                return;
            }
            else if (!IsValidPhoneNum(TestCentre.PhoneNum))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Phone Number", "Please enter a valid phone number.", "OK");
                return;
            }
            else
            {
                await FirebaseDBConnection.AddCentreAsync(TestCentre); 
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public string CentreName
        {
            get { return TestCentre.CentreName; }
            set
            {
                TestCentre.CentreName = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNum
        {
            get { return TestCentre.PhoneNum; }
            set
            {
                TestCentre.PhoneNum = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan OpeningTime
        {
            get { return TestCentre.OpeningTime; }
            set
            {
                TestCentre.OpeningTime = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan ClosingTime
        {
            get { return TestCentre.ClosingTime; }
            set
            {
                TestCentre.ClosingTime = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return TestCentre.Address; }
            set
            {
                TestCentre.Address = value;
                OnPropertyChanged();
            }
        }

    }
}
