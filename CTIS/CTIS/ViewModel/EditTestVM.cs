using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class EditTestVM : BaseVM
    {
        public static CovidTest CovidTest { get; set; }
        public ObservableCollection<string> StatusList { get; set; }

        public ObservableCollection<string> ResultList { get; set; }
        public Command SaveCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command BackCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public EditTestVM()
        {
            ResultList = new ObservableCollection<string>();
            StatusList = new ObservableCollection<string>();
            SaveCommand = new Command(SaveExecute);
            CancelCommand = new Command(CancelExecute);
            DeleteCommand = new Command(DeleteExecute);

            ResultList.Add("Positive");
            ResultList.Add("Negative");

            StatusList.Add("Pending Result");
            StatusList.Add("Test Completed");

            PatientName = CovidTest.PatientName;
            Result = CovidTest.Result;
            ResultDate = CovidTest.ResultDate;
            Status = CovidTest.Status;
            TestDate = CovidTest.TestDate;
            TestID = CovidTest.TestID;
            TestedBy = CovidTest.TestedBy;
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


        public DateTime TestDate
        {
            get { return CovidTest.TestDate; }
            set
            {
                CovidTest.TestDate = value;
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

        public string TestID
        {
            get { return CovidTest.TestID; }
            set
            {
                CovidTest.TestID = value;
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

        private async void DeleteExecute(object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Delete Confirmation", "Are you sure to delete this Test?", "Yes", "No");
            await FirebaseDBConnection.DeleteTestAsync(CovidTest);
            Application.Current.MainPage = new NavigationPage(new UpdateTest());
        }


        private async void CancelExecute(Object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Cancel Confirmation", "Your changes will not be saved. Are you sure?", "Yes", "No");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //Update Test Kit 
        private async void SaveExecute(Object obj)
        {
            if (string.IsNullOrWhiteSpace(CovidTest.TestID) &&
                string.IsNullOrWhiteSpace(CovidTest.Status))
            {
                await Application.Current.MainPage.DisplayAlert("Missing field", "Test kit name or current stock cannot be empty.", "OK");
                return;
            }
            else
            {
                await FirebaseDBConnection.EditTestAsync(CovidTest);
                Application.Current.MainPage = new NavigationPage(new UpdateTest());
            }
        }

    }
}