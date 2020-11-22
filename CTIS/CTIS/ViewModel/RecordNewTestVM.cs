using CTIS.Model;
using CTIS.Utilities;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    public class RecordNewTestVM : BaseVM
    {
        public CovidTest CovidTest { get; set; }
        public ObservableCollection<string> StatusList { get; set; }
        public ObservableCollection<string> ResultList { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command BackCommand { get; set; }


        public RecordNewTestVM()
        {
            CovidTest = new CovidTest();
            StatusList = new ObservableCollection<string>();
            ResultList = new ObservableCollection<string>();
            StatusList.Add("Pending result");
            StatusList.Add("Test completed");
            StatusList.Add("Under review");
            ResultList.Add("Positive");
            ResultList.Add("Negative");
            Status = "Pending result";
            TestedBy = App.User.Name;
            SaveCommand = new Command(SaveExecute);
            BackCommand = new Command(BackExecute);
            CancelCommand = new Command(CancelExecute);
            CovidTest.TestDate = DateTime.Today;
        }

        private async void BackExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void CancelExecute(Object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Cancel Confirmation", "Your input will not be saved. Are you sure?", "Yes", "No");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void SaveExecute(Object obj)
        {
            if (string.IsNullOrWhiteSpace(CovidTest.PatientName))
            {
                await Application.Current.MainPage.DisplayAlert("Missing field", "Patient name cannot be empty.", "OK");
                return;
            }
            else
            {
                await FirebaseDBConnection.AddTestAsync(CovidTest);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public string PatientName
        {
            get { return CovidTest.PatientName; }
            set
            {
                CovidTest.PatientName = value;
                OnPropertyChanged();
            }
        }

        public DateTime TestDate
        {
            get { return CovidTest.TestDate; }
            set
            {
                CovidTest.TestDate = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get { return CovidTest.Result; }
            set
            {
                CovidTest.Result = value;
                OnPropertyChanged();
            }
        }

        public DateTime ResultDate
        {
            get { return CovidTest.ResultDate; }
            set
            {
                CovidTest.ResultDate = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get { return CovidTest.Status; }
            set
            {
                CovidTest.Status = value;
                OnPropertyChanged();
            }
        }

        public string TestedBy
        {
            get { return CovidTest.TestedBy; }
            set
            {
                CovidTest.TestedBy = value;
                OnPropertyChanged();
            }
        }
    }
}
